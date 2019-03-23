
//
// Manages the browser's navigation URL.
//
// Returns methods and fields used to manipulate the browser's URL.
//   url: The current URL in the browser's navigation bar.
//      location: The current window.location.
//      path: Information on the path part of the URL.
//         components: Array of strings, which are the paths in the URL.
//         first: String that is the first path in the components array.
//         last: String that is the last path in the components array.
//         toString: Function that creates a string with all the path components combined.
//      queryParams: Information on the query parameter part of the URL.
//         params: Array of key/value pairs that represent the query parameters.
//           key: Key of the query parameter.
//           value: Value of the query parameter.
//         toString: Function that creates a string with all the query parameters combined.
//
// Many methods take a settings object with the following common fields:
//   state: object (Optional) - Passed to history.pushState as the state argument.  State associated with the new history created by pushState().  Default is undefined.
//   title: string (Optional) - Passed to history.pushState as the title argument.  Title of the state.  Default is undefined.
//   replace: bool (Optional) - Set to true to replace the current history.  Set to false to create a new history.  Default is false.
//   addIfAbsent: bool (Optional) - Set to true to add a query parameter to the URL if it is not there already.
//   raisePopState: bool (Optional) - Set to true to raise a PopState event when changing the URL.
//
function navigationUrl() {
    function sync() {
        var components = window.location.pathname.split("/").filter(function (i) { return i !== ""; });
        var queryParams = window.location.search.substring(1).split("&").filter(function (i) { return i !== ""; });
        var params = [];
        for (var i = 0; i < queryParams.length; i++) {
            var pair = queryParams[i].split("=");
            params.push({ key: pair[0], value: pair[1] });
        }
        return {
            location: window.location,
            path: {
                components: components,
                first: components ? components[0] : null,
                last: components ? components[components.length - 1] : null,
                toString: function () {
                    var result = "";
                    for (var i = 0; i < components.length; i++) {
                        result += "/" + components[i];
                    }
                    return result;
                }
            },
            queryParams: {
                params: params,
                toString: function () {
                    var result = "";
                    for (var i = 0; i < params.length; i++) {
                        result += (i > 0 ? "&" : "?") + params[i].key + "=" + params[i].value;
                    }
                    return result;
                }
            }
        };
    }

    var url = sync();

    function pushNewState(settings) {
        if (settings.replace) {
            history.replaceState(settings ? settings.state : null, !settings || (settings.title === null || settings.title === undefined) ? "" : settings.title, buildUrl());
        } else {
            history.pushState(settings ? settings.state : null, !settings || (settings.title === null || settings.title === undefined) ? "" : settings.title, buildUrl());
        }
        if (settings.raisePopState) {
            var event = new PopStateEvent("popstate", { state: settings.state });
            window.dispatchEvent(event);
        }
        url = sync();
        return url;
    }

    function splitUrl(url) {
        var result = {};
        var state = "protocol";
        var part = "";

        for (var i = 0; i < url.length; i++) {
            var c = url[i];
            if (state === "protocol") {
                if (c === ':') {
                    if (url[i + 1] !== '/' || url[i + 2] !== '/') {
                        throw new Error("Invalid URL");
                    }
                    state = "host";
                    i += 2;
                    continue;
                }
                result.protocol = result.protocol ? result.protocol + c : c;
            }
            else if (state === "host") {
                if (c === ':') {
                    state = "port";
                    continue;
                }
                else if (c === '/') {
                    state = "path";
                    continue;
                }
                else if (c === '?') {
                    state = "query";
                    continue;
                }
                else if (c === '#') {
                    state = "hash";
                    continue;
                }
                result.host = result.host ? result.host + c : c;
            }
            else if (state === "port") {
                if (c === '/') {
                    state = "path";
                    continue;
                }
                else if (c === '?') {
                    state = "query";
                    continue;
                }
                else if (c === '#') {
                    state = "hash";
                    continue;
                }
                result.port = result.port ? result.port + c : c;
            }
            else if (state === "path") {
                if (c === '/') {
                    if (part) {
                        if (!result.paths) {
                            result.paths = [];
                        }
                        result.paths.push(part);
                        part = "";
                    }
                    if (i !== url.length - 1 && url[i + 1] !== '?' && url[i + 1] !== '#') {
                        result.path = result.path ? result.path + c : c;
                    }
                    continue;
                }
                if (c === '?') {
                    if (part) {
                        if (!result.paths) {
                            result.paths = [];
                        }
                        result.paths.push(part);
                        part = "";
                    }
                    state = "query";
                    continue;
                }
                if (c === '#') {
                    if (part) {
                        if (!result.paths) {
                            result.paths = [];
                        }
                        result.paths.push(part);
                        part = "";
                    }
                    state = "hash";
                    continue;
                }
                part += c;
                result.path = result.path ? result.path + c : c;
            }
            else if (state === "query") {
                if (c === '&') {
                    if (part) {
                        if (!result.queries) {
                            result.queries = [];
                        }
                        result.queries.push(part);
                        part = "";
                    }
                    if (i !== url.length - 1) {
                        result.query = result.query ? result.query + c : c;
                    }
                    continue;
                }
                else if (c === '#') {
                    if (part) {
                        if (!result.queries) {
                            result.queries = [];
                        }
                        result.queries.push(part);
                        part = "";
                    }
                    state = "hash";
                    continue;
                }
                part += c;
                result.query = result.query ? result.query + c : c;
            }
            else if (state === "hash") {
                result.hash = result.hash ? result.hash + c : c;
            }
        }

        if (result.port) {
            result.port = parseInt(result.port, 10);
        }

        if (part) {
            if (state === "path") {
                if (!result.paths) {
                    result.paths = [];
                }
                result.paths.push(part);
            }
            else if (state === "query") {
                if (!result.queries) {
                    result.queries = [];
                }
                result.queries.push(part);
            }
        }

        return result;
    }

    function buildUrl() {
        return url.location.protocol + "//" + url.location.host + url.path.toString() + url.queryParams.toString() + url.location.hash;
    }

    //
    // Appends a path to the end of the URL.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com
    //   Call: navigationUrl().appendPath({path: "user/4"})
    //   navigationUrl().url is now: http://www.example.com/user/4
    //
    function appendPath(settings) {
        if (settings && settings.path) {
            url.path.components.push(settings.path);
            return pushNewState({
                state: settings.state,
                title: settings.title,
                raisePopState: settings.raisePopState
            });
        }
        return url;
    }

    //
    // Replaces the last path component in the URL.
    // If the URL does not have a path component, the URL is unchanged.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com/user/4
    //   Call: navigationUrl().replaceLastPath({path: "3"})
    //   navigationUrl().url is now: http://www.example.com/user/3
    //
    function replaceLastPath(settings) {
        if (settings && settings.path && url.path.components.length > 0) {
            url.path.components[url.path.components.length - 1] = settings.path;
            return pushNewState({
                state: settings.state,
                title: settings.title,
                raisePopState: settings.raisePopState
            });
        }
        return url;
    }

    //
    // Removes the last path component in the URL.
    // If the URL does not have a path component, the URL is unchanged.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com/user/4
    //   Call: navigationUrl().removeLastPath()
    //   navigationUrl().url is now: http://www.example.com/user
    //
    function removeLastPath(settings) {
        if (url.path.components.length > 0) {
            url.path.components.pop();
            return pushNewState({
                state: settings.state,
                title: settings.title,
                raisePopState: settings.raisePopState
            });
        }
        return url;
    }

    //
    // Returns the last path component in the URL.
    // If the URL does not have a path component, undefined is returned.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com/user/4
    //   navigationUrl().getLastPath() returns: 4
    //
    //   navigationUrl().url is: http://www.example.com
    //   navigationUrl().getLastPath() returns: undefined
    //
    function getLastPath() {
        if (url.path.components.length > 0) {
            return url.path.components[url.path.components.length - 1];
        }
    }

    //
    // Returns the value of the query parameter with the specified key.
    // If a parameter with the specified key is not found, defaultValue is returned.
    // The defaultValue argument can be undefined, in which case, if the specified key
    // is not found, then undefined is returned.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com?user=4
    //   navigationUrl().findQueryParam("user") returns: 4
    //   navigationUrl().findQueryParam("group") returns: undefined
    //
    function findQueryParam(key, defaultValue) {
        if (key) {
            var params = url.queryParams.params.filter(function (i) { return i.key === key });
            return params.length > 0 ? params[0].value : defaultValue;
        }
    };

    //
    // Appends the query parameter to the URL.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com
    //   Call: navigationUrl().appendQueryParam({key: "user", value: 4})
    //   navigationUrl().url is now: http://www.example.com?user=4
    //
    //   navigationUrl().url is: http://www.example.com?user=4
    //   Call: navigationUrl().appendQueryParam({key: "group", value: "admin"})
    //   navigationUrl().url is now: http://www.example.com?user=4&group=admin
    //
    function appendQueryParam(settings) {
        if (settings && settings.key) {
            if (findQueryParam(settings.key)) {
                return updateQueryParam(settings);
            }
            if (settings.value !== undefined) {
                url.queryParams.params.push({ key: settings.key, value: settings.value });
                pushNewState({
                    state: settings.state,
                    title: settings.title,
                    raisePopState: settings.raisePopState
                });
            }
        }
        return navigationUrl();
    }

    //
    // Updates the query parameter with the specified key to the specified value.
    // If the key is not found and settings.addIfAbsent is true, the parameter is appended to the URL.
    // If the key is not found and settings.addIfAbsent is false, the URL is unchanged.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com?user=3
    //   Call: navigationUrl().updateQueryParam({key: "user", value: 4})
    //   navigationUrl().url is now: http://www.example.com?user=4
    //
    //   navigationUrl().url is: http://www.example.com?user=4
    //   Call: navigationUrl().updateQueryParam({key: "group", value: "admin", addIfAbsent: true})
    //   navigationUrl().url is now: http://www.example.com?user=4&group=admin
    //
    function updateQueryParam(settings) {
        if (settings && settings.key) {
            var found = false;
            for (var i = 0; i < url.queryParams.params.length; i++) {
                if (settings.key === url.queryParams.params[i].key) {
                    url.queryParams.params[i].value = settings.value;
                    found = true;
                    break;
                }
            }
            if (!found) {
                if (settings.addIfAbsent) {
                    return appendQueryParam(settings);
                }
            } else {
                pushNewState({
                    state: settings.state,
                    title: settings.title,
                    raisePopState: settings.raisePopState
                });
            }
        }
        return navigationUrl();
    }

    //
    // Removes the query parameter with the specified key.
    // If no query parameter has the specified key, the URL is unchanged.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com?user=4
    //   Call: navigationUrl().removeQueryParam({key: "user"})
    //   navigationUrl().url is now: http://www.example.com
    //
    //   navigationUrl().url is: http://www.example.com?user=4
    //   Call: navigationUrl().removeQueryParam({key: "group"})
    //   navigationUrl().url is now: http://www.example.com?user=4
    //
    function removeQueryParam(settings) {
        if (settings && settings.key) {
            for (var i = 0; i < url.queryParams.params.length; i++) {
                if (settings.key === url.queryParams.params[i].key) {
                    url.queryParams.params.splice(i, 1);
                    break;
                }
            }
            pushNewState({
                state: settings.state,
                title: settings.title,
                raisePopState: settings.raisePopState
            });
        }
        return navigationUrl();
    }

    //
    // Navigates the browser to the specified URL
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com
    //   Call: navigationUrl().goToUrl("http://www.foobar.com")
    //   navigationUrl().url is now: http://www.foobar.com
    //
    function goToUrl(newUrl) {
        if (newUrl) {
            window.location.href = newUrl;
        }
        else {
            window.location.href = navigationUrl().url.location.href;
        }
        return navigationUrl();
    }

    return {
        url: url,
        appendPath: appendPath,
        replaceLastPath: replaceLastPath,
        removeLastPath: removeLastPath,
        getLastPath: getLastPath,
        findQueryParam: findQueryParam,
        appendQueryParam: appendQueryParam,
        updateQueryParam: updateQueryParam,
        removeQueryParam: removeQueryParam,
        goToUrl: goToUrl,
        splitUrl: splitUrl
    };
}
