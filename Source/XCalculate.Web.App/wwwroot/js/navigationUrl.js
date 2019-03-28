
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
            var pair = queryParams[i].split("=").filter(function (i) { return i !== ""; });
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
            history.replaceState(settings ? settings.state : null, !settings || (settings.title === null || settings.title === undefined) ? "" : settings.title, buildUrl(url.location.protocol, url.location.hostname, url.location.port, url.path.components, + url.queryParams.params, url.location.hash));
        } else {
            history.pushState(settings ? settings.state : null, !settings || (settings.title === null || settings.title === undefined) ? "" : settings.title, buildUrl(url.location.protocol, url.location.hostname, url.location.port, url.path.components, + url.queryParams.params, url.location.hash));
        }
        if (settings.raisePopState) {
            var event = new PopStateEvent("popstate", { state: settings.state });
            window.dispatchEvent(event);
        }
        url = sync();
        return url;
    }

    //
    // Splits a URL into its constituent parts.
    //
    // Returns an object with the URL parts
    //   {
    //     protocol: (String) The protocol of the URL.
    //     host: (String) The host name of the URL.
    //     port: (Number) The port of the URL.  Undefined if none.
    //     path: (String) The path of the URL.  Undefined if none.
    //     paths: (Array of Strings) The path of the URL broken up into components.  Undefined if none.
    //     query: (String) The query part of the URL.  Undefined if none.
    //     queries: (Array of Strings) The query part of the URL broken up into components.  Undefined if none.
    //     hash: (String) The hash part of the URL.  Undefined if none.
    //   }
    //
    function splitUrl(url) {
        var result = {};
        var state = "protocol";
        var part = "";

        var processPathPart = function (result, i, c, url, part) {
            if (part) {
                if (!result.paths) {
                    result.paths = [];
                }
                result.paths.push(part);
            }
        };

        var processQueryPart = function (result, i, c, url, part) {
            if (part) {
                if (!result.queries) {
                    result.queries = [];
                }
                var pair = part.split("=").filter(function (i) { return i !== ""; });
                result.queries.push({ key: pair[0], value: pair[1] });
            }
        };

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
                    processPathPart(result, i, c, url, part);
                    if (i !== url.length - 1 && url[i + 1] !== '?' && url[i + 1] !== '#') {
                        result.path = result.path ? result.path + c : c;
                    }
                    part = "";
                    continue;
                }
                if (c === '?') {
                    processPathPart(result, i, c, url, part);
                    part = "";
                    state = "query";
                    continue;
                }
                if (c === '#') {
                    processPathPart(result, i, c, url, part);
                    part = "";
                    state = "hash";
                    continue;
                }
                part += c;
                result.path = result.path ? result.path + c : c;
            }
            else if (state === "query") {
                if (c === '&') {
                    processQueryPart(result, i, c, url, part);
                    if (i !== url.length - 1) {
                        result.query = result.query ? result.query + c : c;
                    }
                    part = "";
                    continue;
                }
                else if (c === '#') {
                    processQueryPart(result, i, c, url, part);
                    state = "hash";
                    part = "";
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
                var pair = part.split("=").filter(function (i) { return i !== ""; });
                result.queries.push({ key: pair[0], value: pair[1] });
            }
        }

        return result;
    }

    //
    // Builds a URL string given the components of a URL.
    //
    // Returns: String representation of a URL.
    //
    // protocol: (String) Protocol of the URL.
    // hostname: (String) Hostname of the URL.
    // port: (Number) Port of the URL.
    // paths: (Array of Strings) Individual paths of the URL.
    // queries: (Array of Objects) Individual query parameters (in the form { key: string, value: string }) of the URL.
    // hash: (String) Hash part of the URL.
    //
    function buildUrl(protocol, hostname, port, paths, queries, hash) {
        return buildUrlProtocol(protocol) + "//" + hostname + buildUrlPort(port) + buildUrlPath(paths) + buildUrlQuery(queries) + buildUrlHash(hash);
    }

    function buildUrlProtocol(protocol) {
        var str = "";
        if (protocol) {
            str = protocol[protocol.length - 1] === ':' ? protocol : protocol + ":";
        }
        return str;
    }

    function buildUrlPort(port) {
        var str = "";
        if (port) {
            if (port instanceof Number) {
                str = ":" + port;
            }
            else if (port instanceof String) {
                str = port[0] === ':' ? port : ":" + port;
            }
        }
        return str;
    }

    function buildUrlPath(paths) {
        var str = "";
        if (paths) {
            if (paths instanceof Array) {
                for (var i = 0; i < paths.length; i++) {
                    str += "/" + paths[i];
                }
            }
            else if (paths instanceof String) {
                if (paths.length > 0) {
                    str = paths[0] === '/' ? paths : "/" + paths;
                }
            }
        }
        return str;
    }

    function buildUrlQuery(queries) {
        var str = "";
        if (queries) {
            if (queries instanceof Array) {
                for (var i = 0; i < queries.length; i++) {
                    str += (i > 0 ? "&" : "?") + queries[i].key + "=" + queries[i].value;
                }
            }
            else if (queries instanceof String) {
                if (queries.length > 0) {
                    str = queries[0] === '?' ? queries : "?" + queries;
                }
            }
        }
        return str;
    }

    function buildUrlHash(hash) {
        var str = "";
        if (hash) {
            str = hash[0] === '#' ? hash : "#" + hash;
        }
        return str;
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
    // Updates the URL with the specified path.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com/hello/world
    //   Call: navigationUrl().updateUrl("http://www.example.com/foo/bar")
    //   navigationUrl().url is now: http://www.example.com/foo/bar
    //
    function updatePath(settings) {
        if (settings && settings.path) {
            var parts = [];

            if (settings.path instanceof Array) {
                parts = settings.path;
            }
            else if (settings.path instanceof String ) {
                parts = settings.path.split("/");
                //if (parts[parts.length - 1] === "/") {
                //    parts.splice(parts.length - 1, 1);
                //}
            }
            url.path.components.splice(0, url.path.components.length);
            for (var part of parts) {
                url.path.components.push(part);
            }
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
            var params = url.queryParams.params.filter(function (i) { return i.key === key; });
            return params.length > 0 ? params[0].value : defaultValue;
        }
    }

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
    // Updates the URL in the browser window.
    //
    // Returns the new URL.
    //
    // Example:
    //   navigationUrl().url is: http://www.example.com/hello/1?foo=bar
    //   Call: navigationUrl().updateUrl("http://www.example.com/world?bar=foo")
    //   navigationUrl().url is now: http://www.example.com/world?bar=foo
    //
    function updateUrl(settings) {
        if (settings && settings.url) {
            var urlParts = splitUrl(settings.url);
            url.path.components.splice(0, url.path.components.length);
            for (var p of urlParts.paths) {
                url.path.components.push(p);
            }
            url.queryParams.params.splice(0, url.queryParams.params.length);
            for (var q of urlParts.queries) {
                url.queryParams.params.push(q);
            }
            return pushNewState({
                state: settings.state,
                title: settings.title,
                raisePopState: settings.raisePopState
            });
        }
        return url;
    }

    //
    // Navigates the browser to the specified URL.
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
            window.location = newUrl;
        }
        else {
            window.location = navigationUrl().url.location.href;
        }
        return navigationUrl();
    }

    return {
        url: url,
        appendPath: appendPath,
        updatePath: updatePath,
        replaceLastPath: replaceLastPath,
        removeLastPath: removeLastPath,
        getLastPath: getLastPath,
        findQueryParam: findQueryParam,
        appendQueryParam: appendQueryParam,
        updateQueryParam: updateQueryParam,
        removeQueryParam: removeQueryParam,
        updateUrl: updateUrl,
        goToUrl: goToUrl,
        splitUrl: splitUrl,
        buildUrl: buildUrl
    };
}

function testSplitUrl() {
    function checkUrlObject(actual, expected) {
        var props = ["protocol", "host", "port", "path", "query", "hash", "paths", "queries" ];
        if (!actual || !expected) {
            return { success: false, message: "Actual and/or Expected were either undefined or null." };
        }
        for (var prop of props) {
            if (actual[prop] instanceof Array) {
                if (actual[prop] && expected[prop]) {
                    if (actual[prop].length !== expected[prop].length) {
                        return { success: false, message: `Actual ${prop} length ${actual[prop].length} does not equal Expected ${prop} length ${expected[prop].length}.` };
                    }
                    for (var i = 0; i < actual[prop].length; i++) {
                        if (expected[prop][i] instanceof Object) {
                            var pairProps = Object.getOwnPropertyNames(expected[prop][i]);
                            for (var j = 0; j < pairProps.length; j++) {
                                if (actual[prop][i][j] !== expected[prop][i][j]) {
                                    return { success: false, message: `Actual ${prop}[${i}].${j} (${actual[prop][i][j]}) does not equal Expected ${prop}[${i}].${j} (${expected[prop][i][j]}).` };
                                }
                            }
                        }
                        else {
                            if (actual[prop][i] !== expected[prop][i]) {
                                return { success: false, message: `Actual ${prop}[${i}] (${actual[prop][i]}) does not equal Expected ${prop}[${i}] (${expected[prop][i]}).` };
                            }
                        }
                    }
                }
            }
            else {
                if (actual[prop] !== expected[prop]) {
                    return { success: false, message: `Actual ${prop} (${actual[prop]}) does not equal Expected ${prop} (${expected[prop]}).` };
                }
            }
        }
        return { success: true };
    }

    function runTest(navUrl, testUrl, expected) {
        var url = navUrl.splitUrl(testUrl);
        var result = checkUrlObject(url, expected);
        if (result.success) {
            console.log(`Test \"${testUrl}\" succeeded.`);
        }
        else {
            console.log(`Test \"${testUrl}\" failed.`);
            console.log(`  ${result.message}`);
        }
    }

    var testCases = [
        { url: "https://www.example.com", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com/", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com:5000", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/hello", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello", paths: [ "hello" ] }},
        { url: "https://www.example.com:5000/hello/", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello", paths: ["hello"] }},
        { url: "https://www.example.com:5000/hello/world", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"] }},
        { url: "https://www.example.com:5000/hello/world/", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"] }},
        { url: "https://www.example.com:5000/hello/world?foo=bar", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [ { key: "foo", value: "bar" } ] }},
        { url: "https://www.example.com:5000/hello/world/?foo=bar", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }] }},
        { url: "https://www.example.com:5000/hello/world?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com:5000/hello/world/?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com/hello", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"] }},
        { url: "https://www.example.com/hello/", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"] }},
        { url: "https://www.example.com/hello/world", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"] }},
        { url: "https://www.example.com/hello/world/", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"] }},
        { url: "https://www.example.com/hello/world?foo=bar", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }] }},
        { url: "https://www.example.com/hello/world/?foo=bar", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }] }},
        { url: "https://www.example.com/hello/world?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com/hello/world/?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com/hello?foo=bar", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }] }},
        { url: "https://www.example.com/hello/?foo=bar", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }] }},
        { url: "https://www.example.com?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com/?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com:5000?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", port: 5000, query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com:5000/?foo=bar&a=b", expected: { protocol: "https", host: "www.example.com", port: 5000, query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }] }},
        { url: "https://www.example.com?", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com/?", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com:5000?", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/?", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/hello/world#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], hash: "baz" }},
        { url: "https://www.example.com:5000/hello/world/#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], hash: "baz" }},
        { url: "https://www.example.com/hello/world#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], hash: "baz" }},
        { url: "https://www.example.com/hello/world/#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], hash: "baz" }},
        { url: "https://www.example.com/hello#baz", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], hash: "baz" }},
        { url: "https://www.example.com/hello/#baz", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], hash: "baz" }},
        { url: "https://www.example.com#baz", expected: { protocol: "https", host: "www.example.com", hash: "baz" }},
        { url: "https://www.example.com/#baz", expected: { protocol: "https", host: "www.example.com", hash: "baz" }},
        { url: "https://www.example.com:5000#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, hash: "baz" }},
        { url: "https://www.example.com:5000/#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, hash: "baz" }},
        { url: "https://www.example.com#", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com/#", expected: { protocol: "https", host: "www.example.com" }},
        { url: "https://www.example.com:5000#", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/#", expected: { protocol: "https", host: "www.example.com", port: 5000 }},
        { url: "https://www.example.com:5000/hello/world?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com:5000/hello/world/?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com:5000/hello/world?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com:5000/hello/world/?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com/hello/world?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com/hello/world/?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com/hello/world?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com/hello/world/?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", path: "hello/world", paths: ["hello", "world"], query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com/hello?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com/hello/?foo=bar#baz", expected: { protocol: "https", host: "www.example.com", path: "hello", paths: ["hello"], query: "foo=bar", queries: [{ key: "foo", value: "bar" }], hash: "baz" }},
        { url: "https://www.example.com?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com/?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com:5000?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com:5000/?foo=bar&a=b#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, query: "foo=bar&a=b", queries: [{ key: "foo", value: "bar" }, { key: "a", value: "b" }], hash: "baz" }},
        { url: "https://www.example.com?#baz", expected: { protocol: "https", host: "www.example.com", hash: "baz" }},
        { url: "https://www.example.com/?#baz", expected: { protocol: "https", host: "www.example.com", hash: "baz" }},
        { url: "https://www.example.com:5000?#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, hash: "baz" }},
        { url: "https://www.example.com:5000/?#baz", expected: { protocol: "https", host: "www.example.com", port: 5000, hash: "baz" }}
    ];

    var navUrl = navigationUrl();
    for (var i = 0; i < testCases.length; i++) {
        runTest(navUrl, testCases[i].url, testCases[i].expected);
    }
}