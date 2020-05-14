/* IE Fix for the use of attribute ='placeholder' */
$(function() {
    if (!$.support.placeholder) {
        var active = document.activeElement;

        $(':text').focus(function() {
            if ($(this).attr('placeholder') != '' && $(this).val() == $(this).attr('placeholder')) {
                $(this).val('').removeClass('hasPlaceholder');
            }
        }).blur(function() {
            if ($(this).attr('placeholder') != '' && ($(this).val() == '' || $(this).val() == $(this).attr('placeholder'))) {
                $(this).val($(this).attr('placeholder')).addClass('hasPlaceholder');
            }
        });
        $(':text').blur();

        $(active).focus();
    }
});
/* Search Modal function */
function searchModal() {
    jQuery('#searchBox').modal({
        minWidth: 597,
        minHeight: 135,
        closeClass: "modalClose",
        closeHTML: "<a href='#'></a>",
        overlayClose: true
    });
}
/* Site content section resizing depending on Left Bar or Right Bar is enabled. */
jQuery(function() {

    var sw = jQuery('#mainContainer').width();
    var lb = jQuery('#leftBar').width() + 32;
    var rb = jQuery('#rightBar').width() + 32;
    var mw = sw - (lb + rb);

    if (jQuery('#leftBar').length == 0 || jQuery('#rightBar').length == 0) {
        if (jQuery('#leftBar').length == 0 && jQuery('#rightBar').length == 0) {
            jQuery('#mainContent').css('width', '100%');
        } else {
            jQuery('#mainContent').css('width', mw + 32 + 'px');
        }
    } else {
        jQuery('#mainContent').css('width', mw + 'px');
    }

    if (jQuery('#leftBar').css('display') == 'none' || jQuery('#rightBar').css('display') == 'none') {
        jQuery('#mainContent').css('width', '100%');
    } else {
        if (jQuery('#leftBar').css('display') == 'block' || jQuery('#rightBar').css('display') == 'block') {
            jQuery('#mainContent').css('width', mw + 32 + 'px');
        }
    }

    /* On the window resize event. */
    jQuery(window).resize(function() {

        if (jQuery('#leftBar').css('display') == 'none' || jQuery('#rightBar').css('display') == 'none') {
            jQuery('#mainContent').css('width', '100%');
        } else {
            if (jQuery('#leftBar').css('display') == 'block' || jQuery('#rightBar').css('display') == 'block') {
                jQuery('#mainContent').css('width', mw + 32 + 'px');
            }
        }

    });

    /* On the device orientation change event. */
    jQuery(window).bind('orientationchange', function(event) {

        if (orientation == 0 || orientation == 180) {
            jQuery('#mainContent').css('width', '100%');
        } else {
            if (jQuery('#leftBar').css('display') == 'block' || jQuery('#rightBar').css('display') == 'block') {
                //alert('new orientation:' + orientation);
                jQuery('#mainContent').css('width', mw + lb + 32 + 'px');
            } else {
                jQuery('#mainContent').css('width', '100%');
            }
        }
    });

    /* Initiates toggle for mobile drop down menu */
    jQuery('a#mobileMenu').on('click', function() {
        jQuery('ul.mobile').toggle();
    });

    /* Initiates <select> for Sub-Category & Blog menus at a specified width. */
    if (jQuery(window).width() <= 767) {

        jQuery('#blog .blogNav ul, #subcategoriesBlock ul').each(function() {
            var list = jQuery(this),
                select = jQuery(document.createElement('select')).insertBefore(jQuery(this).hide());

            jQuery('>li a', this).each(function() {
                var target = jQuery(this).attr('target'),
                    option = jQuery(document.createElement('option'))
                    .appendTo(select)
                    .val(this.href)
                    .html(jQuery(this).html())
                    .click(function() {});
            });
            list.remove();
        });

        jQuery('#blog .blogNav select:eq(0)').prepend('<option> --- Select Category ---</option>');
        jQuery('#blog .blogNav select:eq(1)').prepend('<option> --- Select Recent Posts ---</option>');
        jQuery('#blog .blogNav select:eq(2)').prepend('<option> --- Select Archives ---</option>');

        jQuery('#subcategoriesBlock select').prepend('<option> --- Select Sub-Category ---</option>');

        jQuery('#blog .blogNav select, #subcategoriesBlock select').change(function() {
            window.location.href = jQuery(this).val();
        });
    } else {
        return;
    }
});