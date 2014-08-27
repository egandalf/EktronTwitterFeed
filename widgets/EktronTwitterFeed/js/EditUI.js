if (Ektron === undefined) {
    Ektron = {};
}
if (Ektron.PFWidgets === undefined) {
    Ektron.PFWidgets = {};
}
Ektron.PFWidgets.EktronTwitterFeed_Edit = {
    init: function (settings) {
        var container = $("#" + settings.ContainerID);
        var enableField = $(container).find("#" + settings.EnableFieldID);
        var enableClass = $(container).find("." + settings.EnableFieldClass);
        $(enableField).on("click", function () {
            if ($(this).attr("checked") == "checked") {
                enableClass.show();
            } else {
                enableClass.hide();
            }
            Ektron.PFWidgets.EktronTwitterFeed_Edit.setRowColors(container);
        });
        if ($(enableField).attr("checked") == "checked") {
            enableClass.show();
        } else {
            enableClass.hide();
        }
        Ektron.PFWidgets.EktronTwitterFeed_Edit.setRowColors(container);
    },
    setRowColors: function (container) {
        var rows = $(container).find("tr");
        $.each(rows, function (index) {
            if (index % 2 == 0) {
                $(this).removeClass("even");
                $(this).addClass("odd");
            } else {
                $(this).removeClass("odd");
                $(this).addClass("even");
            }
        });
    }
};