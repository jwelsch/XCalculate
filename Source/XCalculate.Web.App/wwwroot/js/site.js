//
// OnClick handler that will make an AJAX call.
//
// Returns false to prevent the event from bubbling up the chain.
//
// e: (Object) Element that was clicked.
// config: (Object) Configuration object to control what the function does.
//         type: (String) HTTP method type - "GET" or "POST".  Defaults to "GET".
//         contentType: (String or false) Format of content in the request body.  Defaults to false.
//         node: (String) Identitifer of the HTML node that will be affected by the action.  Defaults to "main".
//         action: (String) Specifies the action to apply to the node - "contain" or "replace".  Defaults to "replace".
//
function onClickAjaxHelper(e, config) {
    config = config ? config : {};

    var url = "";

    if (e instanceof String) {
        url = e;
    }
    else if (e instanceof HTMLAnchorElement) {
        url = e.toString();
    }
    else {
        throw new Error("Unknown type of URL input.");
    }

    var type = config.type ? config.type : "GET";
    var contentType = config.contentType ? config.contentType : false;
    var node = config.node ? config.node : "main";
    var action = config.action ? config.action : "contain";

    $.ajax({
        type: type,
        url: url,
        contentType: contentType,
        success: function (data, status) {
            navigationUrl().updateUrl({ url: url });
            if (action === "replace") {
                $(node).replaceWith(data);
            }
            else {
                $(node).html(data);
            }
        },
        error: function (xhr, status, error) {
            console.log(`AJAX error - status: ${status}; error: ${JSON.string(error)}`);
        }
    });

    return false;
}
