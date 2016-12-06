$(document).ready(function () {
    var url = $("#searcher").attr("data-autocomplete");
    $("#searcher").autocomplete({
        minLength: 2,
        source: function (request, response) {
            $.getJSON(url, { term: request.term }, response);
        }
    }).data('autocomplete')._renderItem = function (ul, item) {
        return $('<li style="font-size:.7em; max-width:700px;"></li>')
                .data('item.autocomplete', item)
                .append('<a><span class="searchtype">'
                      item.TypeName
                  '</span><span class="searchtitle '   item.CssClass   '">'
                  item.Title
                  '</span></a>')
            .appendTo(ul);
    };
});