(function($) {
    "use strict";

    $(document).ready(function() {

        var ScreenWidth = 0;
        var ScreenHeight = 0;
        var ScreenType = 'm';
        var PrevScreenType = '';
        var WebsiteHeight = 0;
        var HeaderHeight = 0;
        var FooterHeight = 0;
        var ContentMinHeight = 0;
        var ContentHeight = 0;
        var Element = '';
        var Offset = 0;
        var TopOffset = 0;
        //var ScrollOffset = 0;

        function ScrollbarWidth() {
            if (jQuery('body').height() > jQuery(window).height()) {
                var calculation_content = jQuery('<div style="width:50px;height:50px;overflow:hidden;position:absolute;top:-200px;left:-200px;"><div style="height:100px;"></div>');
                jQuery('body').append(calculation_content);
                var width_one = jQuery('div', calculation_content).innerWidth();
                calculation_content.css('overflow-y', 'scroll');
                var width_two = jQuery('div', calculation_content).innerWidth();
                jQuery(calculation_content).remove();
                return (width_one - width_two);
            }
            return 0;
        }

        function ScrollToElement(ElementID, $MarginTop) {
            Element = $("[id='" + ElementID + "']");
            $MarginTop = $MarginTop || 0;
            Offset = Element.offset().top - $MarginTop;
            $('html,body').animate({
                scrollTop: Offset
            }, 'slow');
        }

        // resolution checker and fixer
        function ResCheck() {

            // DIMENTIONS DETECTION
            ScreenWidth = $(window).width() + ScrollbarWidth();
            ScreenHeight = $(window).height();

            WebsiteHeight = $('#top').height();
            HeaderHeight = $('.headerbox-wrapper').height();
            ContentHeight = $('.contentbox-wrapper').height();
            FooterHeight = $('.footerbox-wrapper').height();

            // FIXES TO BE APPLIED ONLY WHEN CROSSING RESOLUTION BREAKPOINTS
            PrevScreenType = ScreenType;
            if (ScreenWidth < 768) {
                ScreenType = 'm';
                if (PrevScreenType !== ScreenType) {
                    // hide main navigation
                    $('#nav-release').css({
                        'display': 'block'
                    });
                    $('#nav-main').css({
                        'display': 'none'
                    });
                }
            } else if (ScreenWidth < 1024) {
                ScreenType = 't';
                if (PrevScreenType !== ScreenType) {
                    // hide main navigation
                    $('#nav-release').css({
                        'display': 'block'
                    });
                    $('#nav-main').css({
                        'display': 'none'
                    });
                }
            } else {
                ScreenType = 'd';
                if (PrevScreenType !== ScreenType) {
                    // show main navigation
                    $('#nav-release').css({
                        'display': 'none'
                    });
                    $('#nav-main').css({
                        'display': 'block'
                    });
                }
            }
            if (ScreenWidth < 480) {
                $('#top').addClass('mobile').removeClass('small').removeClass('medium').removeClass('big').removeClass('large').removeClass('humungous').removeClass('hd');
            }
            if (ScreenWidth >= 480) {
                $('#top').addClass('small').removeClass('mobile').removeClass('medium').removeClass('big').removeClass('large').removeClass('humungous').removeClass('hd');
            }
            if (ScreenWidth >= 768) {
                $('#top').addClass('medium').removeClass('mobile').removeClass('small').removeClass('big').removeClass('large').removeClass('humungous').removeClass('hd');
            }
            if (ScreenWidth >= 1024) {
                $('#top').addClass('big').removeClass('mobile').removeClass('small').removeClass('medium').removeClass('large').removeClass('humungous').removeClass('hd');
            }
            if (ScreenWidth >= 1220) {
                $('#top').addClass('large').removeClass('mobile').removeClass('small').removeClass('medium').removeClass('big').removeClass('humungous').removeClass('hd');
            }
            if (ScreenWidth >= 1440) {
                $('#top').addClass('humungous').removeClass('mobile').removeClass('small').removeClass('medium').removeClass('big').removeClass('large').removeClass('hd');
            }
            if (ScreenWidth >= 1920) {
                $('#top').addClass('hd').removeClass('mobile').removeClass('small').removeClass('medium').removeClass('big').removeClass('large').removeClass('humungous');
            }

            // HORIZONTAL/VERTICAL SCREEN DETECTION
            if (ScreenHeight > ScreenWidth) { // vertical screen
                $('#top').removeClass('horizontal');
                $('#top').addClass('vertical');
            } else { // horizontal screen
                $('#top').removeClass('vertical');
                $('#top').addClass('horizontal');
            }

            // LAYOUT SIZES FIXES
            // apply proper minimum height to contentbox-wrapper element
            ContentMinHeight = ScreenHeight - HeaderHeight - FooterHeight;
            $('.contentbox-wrapper').css({
                'min-height': ContentMinHeight + 'px'
            });

            // INFO
            $('.screenSIZE').text(' | ' + ScreenWidth + ' x ' + ScreenHeight + ' ' + ScreenType +
                ' | ' + WebsiteHeight + '=' + HeaderHeight + '+' + ContentHeight + ' (' + ContentMinHeight + ')+' + FooterHeight +
                ' | ' + TopOffset);
        }

        $(window).scroll(function() {
            // update TopOffset value
            TopOffset = $(window).scrollTop();

            // Scroll detection
            if (ScreenType === 'd') {
                if ((TopOffset > 0) && !$('body').hasClass('scrolled')) {
                    $('body').addClass('scrolled');
                }
                if ((TopOffset <= 0) && $('body').hasClass('scrolled')) {
                    $('body').removeClass('scrolled');
                }
            }

            // INFO
            $('.screenSIZE').text(' | ' + ScreenWidth + ' x ' + ScreenHeight + ' ' + ScreenType +
                ' | ' + WebsiteHeight + '=' + HeaderHeight + '+' + ContentHeight + ' (' + ContentMinHeight + ')+' + FooterHeight +
                ' | ' + TopOffset);
        });

        // ------------------------

        ResCheck();
        setTimeout(function() {
            ResCheck();
        }, 500);
        setTimeout(function() {
            ResCheck();
        }, 1000);
        $(window).resize(function() {
            ResCheck();
        });


        // slide rotator initialisation
        //startSlides();

        // little code injections
        //$('.element-class').removeClass('fa-circle').addClass('fa-chevron-circle-right');
        //$('#element-id').prepend('<i class="fa fa-location-arrow"></i> ');
        $('#ban-left a').prepend('<div class="frame"><span></span></div> ');
        $('#ban-right a').prepend('<div class="frame"><span></span></div> ');
        $('#ban-middle a').prepend('<div class="frame"><span></span></div> ');
        $('#productdesription > dl > dt').prepend('<i class="fa fa-fw fa-angle-double-right"></i> ');
        $('#extrapage .content section > dl > dt').prepend('<i class="fa fa-fw fa-angle-double-right"></i> ');

        $('.blog-body img.frame').filter("[align='left']").wrap('<div class="frame-wrapper align-left"><div></div></div>');
        $('.blog-body img.frame').filter("[align='right']").wrap('<div class="frame-wrapper align-right"><div></div></div>');
        $('.blog-body img.frame').filter("[align='center']").wrap('<div class="frame-wrapper"><div></div></div>');
        $('.blog-body img.frame:not([align])').wrap('<div class="frame-wrapper"><div></div></div>');
        $('.blog-body .frame-wrapper > div').append('<div><span></span></div>');

        $('#updateform .button.store-loc a').attr("target", "_blank");

        $('body > div').filter(function() {
            return $(this).css('position') === 'fixed';
        }).css('display', 'none');



        // categories menu layout fixes
        $('#nav-categories > ul > li > ul').has('li').parent().addClass('has-subs');
        $('#nav-categories > ul > li > a').prepend('<i class="fa fa-fw fa-circle"></i> ');
        $('#nav-categories > ul > li.has-subs > a > i.fa').removeClass('fa-circle').addClass('fa-chevron-circle-right');
        $('<li class="back"><i class="fa fa-fw fa-arrow-left" aria-hidden="true"></i> back</li>').insertBefore('#nav-categories > ul > li.has-subs');
        $('#nav-learn > ul > li > a').prepend('<i class="fa fa-fw fa-circle"></i> ');



        // MENUS BEHAVIOUR



        function CloseAllMenus() {
            $('#nav-utils-search').removeClass('open');
            $('#nav-search').removeClass('open').slideUp(200);
            $('#nav-tools .nav-btn').removeClass('open');
            $('#nav-tools .nav-sub').removeClass('open').slideUp(200);
            $('#nav-store-account').removeClass('open');
            $('#nav-store-account-sub').removeClass('open').slideUp(200);
            $('#nav-categories .nav-btn').removeClass('open');
            $('#nav-categories > ul').removeClass('open').slideUp(200);
            $('#nav-learn .nav-btn').removeClass('open');
            $('#nav-learn > ul').removeClass('open').slideUp(200);
        }



        // search for all screens
        $('#nav-utils-search').click(function() {
            if ($(this).hasClass('open')) {
                $(this).removeClass('open');
                $('#nav-search').removeClass('open').slideUp(200);
            } else {
                CloseAllMenus();
                $(this).addClass('open');
                if (ScreenType !== 'd') {
                    $('#nav-search').addClass('open').slideDown(200);
                } else {
                    $('#nav-search').addClass('open').fadeIn(100);
                    $('#curtain').fadeIn(300);
                }
            }
            return false;
        });
        $('#curtain').click(function() {
            $('#nav-utils-search').removeClass('open');
            $('#nav-search').removeClass('open').fadeOut(100);
            $('#curtain').fadeOut(100);
            return false;
        });



        // tools menu
        $('#nav-tools .nav-btn').click(function() {
            if (ScreenType !== 'd') {
                if ($(this).hasClass('open')) {
                    $(this).removeClass('open');
                    $('#nav-tools .nav-sub').removeClass('open').slideUp(200);
                } else {
                    CloseAllMenus();
                    $(this).addClass('open');
                    $('#nav-tools .nav-sub').addClass('open').slideDown(200);
                }
                return false;
            }
        });
        $('#nav-tools .nav-sub li.sub > a').click(function() {
            if (ScreenType !== 'd') {
                if ($(this).parent('li').hasClass('open')) {
                    $(this).parent('li').removeClass('open');
                    $(this).siblings('ul').removeClass('open').slideUp(200);
                    $('> i.fa', this).removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
                } else {
                    $('#nav-tools .nav-sub li.sub').removeClass('open');
                    $('#nav-tools .nav-sub li.sub > ul').removeClass('open').slideUp(200);
                    $('#nav-tools .nav-sub li.sub > a i.fa').removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
                    $(this).parent('li').addClass('open');
                    $(this).siblings('ul').addClass('open').slideDown(200);
                    $('> i.fa', this).removeClass('fa-chevron-circle-right').addClass('fa-chevron-circle-down');
                }
                return false;
            }
        });
        $('#nav-tools .nav-sub li.sub').mouseenter(function() {
            if (ScreenType === 'd') {
                $('> ul', this).addClass('open').slideDown(200);
                $('> a > i.fa', this).removeClass('fa-chevron-circle-right').addClass('fa-chevron-circle-down');
            }
        });
        $('#nav-tools .nav-sub li.sub').mouseleave(function() {
            if (ScreenType === 'd') {
                $('> ul', this).removeClass('open').slideUp(200);
                $('> a > i.fa', this).removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
            }
        });



        // account menu
        $('#nav-store-account').click(function() {
            if (ScreenType !== 'd') {
                if ($(this).hasClass('open')) {
                    $(this).removeClass('open');
                    $('#nav-store-account-sub').removeClass('open').slideUp(200);
                } else {
                    CloseAllMenus();
                    $(this).addClass('open');
                    $('#nav-store-account-sub').addClass('open').slideDown(200);
                }
                return false;
            }
        });
        $('#nav-store-account').mouseenter(function() {
            if (ScreenType === 'd') {
                $('#nav-store-account').addClass('open');
                $('#nav-store-account-sub').addClass('open').slideDown(200);
            }
        });
        $('#nav-store-account').mouseleave(function() {
            if (ScreenType === 'd') {
                if ($('#nav-store-account-sub').is(':hover')) {
                    return;
                }
                $('#nav-store-account').removeClass('open');
                $('#nav-store-account-sub').removeClass('open').slideUp(200);
            }
        });
        $('#nav-store-account-sub').mouseleave(function() {
            if (ScreenType === 'd') {
                $('#nav-store-account').removeClass('open');
                $('#nav-store-account-sub').removeClass('open').slideUp(200);
            }
        });



        // categories menu
        $('#nav-categories .nav-btn').click(function() {
            if ($(this).hasClass('open')) {
                $(this).removeClass('open');
                $('#nav-categories > ul').removeClass('open').slideUp(200);
            } else {
                CloseAllMenus();
                $(this).addClass('open');
                $('#nav-categories > ul').addClass('open').slideDown(200);
            }
            return false;
        });



        // categories menu - subcategories
        $('#nav-categories > ul > li.has-subs > a.cat').click(function() {
            if ($(this).parent('li').hasClass('open')) {
                $(this).parent('li').siblings('li').not('.back').slideDown(200);
                $(this).siblings('ul').slideUp(200);
                $('> i', this).removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
                $(this).parent('li').removeClass('open');
                $(this).parent('li').prev('.back').removeClass('visible');
            } else {
                $(this).parent('li').siblings('li').slideUp(200);
                $(this).siblings('ul').slideDown(200);
                $('> i', this).removeClass('fa-chevron-circle-right').addClass('fa-chevron-circle-down');
                $(this).parent('li').addClass('open');
                $(this).parent('li').prev('.back').addClass('visible');
            }
            return false;
        });
        $('#nav-categories > ul > li.back').click(function() {
            $('#nav-categories > ul > li').not(this).not('.back').slideDown(200);
            $(this).next('li.open').children('ul').slideUp(200);
            $(this).next('li.open').children('a').children('i').removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
            $(this).next('li.open').removeClass('open');
            $(this).removeClass('visible');
            return false;
        });
        $('#nav-categories > ul > li.has-subs > a').mouseenter(function() {
            if (ScreenType === 'd') {
                $('#nav-categories > ul > li.visible').addClass('hov');
            }
        });
        $('#nav-categories > ul > li.has-subs > a').mouseleave(function() {
            if (ScreenType === 'd') {
                $('#nav-categories > ul > li.visible').removeClass('hov');
            }
        });



        // learn menu for all screens
        $('#nav-learn .nav-btn').click(function() {
            //	if(ScreenType !== 'd') {
            if ($(this).hasClass('open')) {
                $(this).removeClass('open');
                $('#nav-learn > ul').removeClass('open').slideUp(200);
            } else {
                CloseAllMenus();
                $(this).addClass('open');
                $('#nav-learn > ul').addClass('open').slideDown(200);
            }
            return false;
            //	}
        });



        // footer menu for mobile screen
        $('#footernav ul.pages > li > span').click(function() {
            if (ScreenType === 'm') {
                if ($(this).parent('li').hasClass('open')) {
                    $('> i', this).removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
                    $(this).siblings('ul').slideUp(200);
                    $(this).parent('li').removeClass('open');
                } else {
                    $('#footernav ul.pages > li.open > span > i').removeClass('fa-chevron-circle-down').addClass('fa-chevron-circle-right');
                    $('#footernav ul.pages > li.open > ul').slideUp(200);
                    $('#footernav ul.pages > li.open').removeClass('open');
                    $('> i', this).removeClass('fa-chevron-circle-right').addClass('fa-chevron-circle-down');
                    $(this).siblings('ul').slideDown(200);
                    $(this).parent('li').addClass('open');
                }
                return false;
            }
        });



        // product listing accordion
        $('#productdesription > dl > dt').mouseenter(function() {
            if ($(this).next().is('dd')) {
                $(this).addClass('hov');
            }
        });
        $('#productdesription > dl > dt').mouseleave(function() {
            if ($(this).next().is('dd')) {
                $(this).removeClass('hov');
            }
        });
        $('#productdesription > dl > dt').click(function() {
            if ($(this).next().is('dd')) {
                if ($(this).next('dd').hasClass('open')) {
                    $('.fa', this).removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                    $(this).removeClass('open');
                    $(this).next('dd').slideUp(200).removeClass('open');
                } else {
                    $('#productdesription > dl > dt.open .fa').removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                    $('#productdesription > dl > dt.open').removeClass('open');
                    $('#productdesription > dl > dt.open').slideUp(200).removeClass('open');
                    $('.fa', this).removeClass('fa-angle-double-right').addClass('fa-angle-double-down');
                    $(this).addClass('open');
                    $(this).next('dd').slideDown(200).addClass('open');
                }
            }
        });

        // extrapage listing accordion


        $('#extrapage .content section > dl > dt').mouseenter(function() {
            if ($(this).next().is('dd')) {
                $(this).addClass('hov');
            }
        });
        $('#extrapage .content section > dl > dt').mouseleave(function() {
            if ($(this).next().is('dd')) {
                $(this).removeClass('hov');
            }
        });
        $('#extrapage .content section > dl > dt').click(function() {
            if ($(this).next().is('dd')) {
                if ($(this).next('dd').hasClass('open')) {
                    $('.fa', this).removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                    $(this).removeClass('open');
                    $(this).next('dd').slideUp(200).removeClass('open');
                } else {
                    $('#extrapage .content section > dl > dt.open .fa').removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                    $('#extrapage .content section > dl > dt.open').removeClass('open');
                    $('#extrapage .content section > dl > dt.open').slideUp(200).removeClass('open');
                    $('.fa', this).removeClass('fa-angle-double-right').addClass('fa-angle-double-down');
                    $(this).addClass('open');
                    $(this).next('dd').slideDown(200).addClass('open');
                }
            }
        });



        // widgets accordion
        $('.widget-accordion > .menu-headers').click(function() {
            if ($(this).hasClass('open')) {
                $('.fa', this).removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                $(this).next('div').slideUp(200);
                $(this).removeClass('open');
            } else {
                $('.widget-accordion > .menu-headers.open .fa').removeClass('fa-angle-double-down').addClass('fa-angle-double-right');
                $('.widget-accordion > .menu-headers.open').next('div').slideUp(200);
                $('.widget-accordion > .menu-headers.open').removeClass('open');
                $('.fa', this).removeClass('fa-angle-double-right').addClass('fa-angle-double-down');
                $(this).addClass('open');
                $(this).next('div').slideDown(200);
            }
        });



        // scroll to comments
        $('#comments .header h2 button').click(function() {
            $('#blogaddcomment').slideDown(200);
            ScrollToElement('blogaddcomment', 100);
        });



        // my account accordion
        $('#myaccount .header h3 .btn-show').click(function() {
            $(this).parent().parent().next('div.hiddenbody').slideDown(200);
            $(this).siblings('.btn-hide').css({
                'display': 'inline-block'
            });
            $(this).css({
                'display': 'none'
            });
        });
        $('#myaccount .header h3 .btn-hide').click(function() {
            $(this).parent().parent().next('div.hiddenbody').slideUp(200);
            $(this).siblings('.btn-show').css({
                'display': 'inline-block'
            });
            $(this).css({
                'display': 'none'
            });
        });

        // checkout accordion
        $('#divCart_head h3 .btn-show').click(function() {
            $('#divCart').slideDown(200);
            $('#divCart_head h3 .btn-hide').css({
                'display': 'inline-block'
            });
            $(this).css({
                'display': 'none'
            });
        });
        $('#divCart_head h3 .btn-hide').click(function() {
            $('#divCart').slideUp(200);
            $('#divCart_head h3 .btn-show').css({
                'display': 'inline-block'
            });
            $(this).css({
                'display': 'none'
            });
        });



        // GALLERY

        if ($('#productimage-btns .image2').attr('style') === 'background-image: url();') {
            $('#productimage-btns .image1').css({
                'display': 'none'
            });
        }

        if ($('#productimage-btns .image1').attr('style') === 'background-image: url();') {
            $('#productimage-btns .image1').css({
                'display': 'none'
            });
        }
        if ($('#productimage-btns .image2').attr('style') === 'background-image: url();') {
            $('#productimage-btns .image2').css({
                'display': 'none'
            });
        }
        if ($('#productimage-btns .image3').attr('style') === 'background-image: url();') {
            $('#productimage-btns .image3').css({
                'display': 'none'
            });
        }
        if ($('#productimage-btns .image4').attr('style') === 'background-image: url();') {
            $('#productimage-btns .image4').css({
                'display': 'none'
            });
        }

        $('#productimage .image2').css('opacity', '0');
        $('#productimage .image3').css('opacity', '0');
        $('#productimage .image4').css('opacity', '0');

        $('#productimage-btns .image1').click(function() {
            $('#productimage .image').css('opacity', '0');
            $('#productimage .image1').css('opacity', '1');
        });
        $('#productimage-btns .image2').click(function() {
            $('#productimage .image').css('opacity', '0');
            $('#productimage .image2').css('opacity', '1');
        });
        $('#productimage-btns .image3').click(function() {
            $('#productimage .image').css('opacity', '0');
            $('#productimage .image3').css('opacity', '1');
        });
        $('#productimage-btns .image4').click(function() {
            $('#productimage .image').css('opacity', '0');
            $('#productimage .image4').css('opacity', '1');
        });


    });

})(jQuery);

// © PIXEL SCIENCE