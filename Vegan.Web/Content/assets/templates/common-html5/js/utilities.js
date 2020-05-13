function click_ship() {}

function toggleoff() {
    for (var i, t = document.getElementsByTagName("div"), n = 0; n < t.length; ++n)(t[n].id.indexOf("shUSPS") >= 0 || t[n].id.indexOf("shUPS") >= 0 || t[n].id.indexOf("shCA Post") >= 0 || t[n].id.indexOf("shFEDEX") >= 0) && (i = document.getElementById(t[n].id)), i != undefined && (i.style.display = "none")
}

function createCookie(n, t, i) {
    var r, u;
    i ? (r = new Date, r.setTime(r.getTime() + i * 864e5), u = "; expires=" + r.toGMTString()) : u = "";
    document.cookie = n + "=" + t + u + "; path=/"
}

function addLoadEvent(n) {
    var t = window.onload;
    window.onload = typeof onload != "function" ? n : function() {
        t && t();
        n()
    }
}

function toggleoff_mul(n) {
    for (var r, i = document.getElementsByTagName("div"), t = 0; t < i.length; ++t)(i[t].id.indexOf("sh" + n + "USPS") >= 0 || i[t].id.indexOf("sh" + n + "UPS") >= 0 || i[t].id.indexOf("sh" + n + "CA Post") >= 0 || i[t].id.indexOf("sh" + n + "FEDEX") >= 0) && (r = document.getElementById(i[t].id)), r != undefined && (r.style.display = "none")
}

function toggle(n) {
    var t;
    t = document.getElementById(n);
    t != undefined && (t.style.display = t.style.display == "none" ? "" : "none")
}

function toggleProdOptions(n) {
    var t;
    t = document.getElementById(n);
    t != undefined && (t.style.display = t.style.display == "none" ? "" : "none")
}

function doclick() {}

function filladdress_form(n, t, i) {
    var f = eval("document." + t),
        u = eval(n),
        r;
    if (u.selectedIndex < 0 && (u.selectedIndex = 0), u.selectedIndex > -1) {
        if (r = u.options[u.selectedIndex].value.split("::"), eval("document." + t + "." + i + "_address").value = r[0], eval("document." + t + "." + i + "_firstname").value = r[1], eval("document." + t + "." + i + "_lastname").value = r[2], eval("document." + t + "." + i + "_address2").value = r[3], eval("document." + t + "." + i + "_city").value = r[4], eval("document." + t + "." + i + "_zip").value = r[5], eval("document." + t + "." + i + "_phone").value = r[8], eval("document." + t + "." + i + "_company").value = r[9], r.length > 10) try {
            eval("document." + t + ".locations_name").value = r[10];
            eval("document." + t + ".locations_store").value = r[11]
        } catch (e) {}
        initCountry(r[7], r[6], i + "_state", i + "_country")
    }
}

function filladdress(n) {
    filladdress_form(n, n.form.name, "shipping");
    try {
        document.getElementById("addressbook").checked = !1;
        document.getElementById("rowAddAddress").style.display = document.getElementById("save_address").selectedIndex + 1 == document.getElementById("save_address").options.length ? "block" : "none"
    } catch (t) {}
    return
}

function submitForm() {
    return isSubmitComplete && bolCheckSubmitted_validation ? (alert("Form already submitted please wait..."), !1) : (isSubmitComplete = !0, !0)
}

function Validator(n) {
    if (this.formobj = document.forms[n], !this.formobj) {
        alert("Error: couldnot get Form object " + n);
        return
    }
    this.formobj.onsubmit ? (this.formobj.old_onsubmit = this.formobj.onsubmit, this.formobj.onsubmit = null) : this.formobj.old_onsubmit = null;
    this.formobj._sfm_form_name = n;
    this.formobj.onsubmit = form_submit_handler;
    this.addValidation = add_validation;
    this.setAddnlValidationFunction = set_addnl_vfunction;
    this.clearAllValidations = clear_all_validations;
    this.disable_validations = !1;
    document.error_disp_handler = new sfm_ErrorDisplayHandler;
    this.EnableOnPageErrorDisplay = validator_enable_OPED;
    this.EnableOnPageErrorDisplaySingleBox = validator_enable_OPED_SB;
    this.show_errors_together = !0;
    this.EnableMsgsTogether = sfm_enable_show_msgs_together;
    this.setOnErrorFunction = set_onerror_function
}

function set_addnl_vfunction(n) {
    this.formobj.addnlvalidation = n
}

function set_onerror_function(n) {
    this.formobj.onerrorfunction = n
}

function sfm_enable_show_msgs_together() {
    this.show_errors_together = !0;
    this.formobj.show_errors_together = !0
}

function clear_all_validations() {
    for (var n = 0; n < this.formobj.elements.length; n++) this.formobj.elements[n].validationset = null
}

function form_submit_handler() {
    var t = !0,
        n;
    for (document.error_disp_handler.clear_msgs(), n = 0; n < this.elements.length; n++)
        if (this.elements[n].classList.contains("hasPlaceholder") && this.elements[n].placeholder == this.elements[n].value && (this.elements[n].value = ""), this.elements[n].validationset && !this.elements[n].validationset.validate() && (t = !1), !t && !this.show_errors_together) break;
    return t ? this.addnlvalidation && (str = " var ret = " + this.addnlvalidation + "()", eval(str), !ret) ? (this.onerrorfunction && (str = this.onerrorfunction + "()", eval(str)), ret) : !0 : (document.error_disp_handler.FinalShowMsg(), this.onerrorfunction && (str = this.onerrorfunction + "()", eval(str)), !1)
}

function add_validation(n, t, i) {
    var u = null,
        r;
    if (arguments.length > 3 && (u = arguments[3]), !this.formobj) {
        alert("Error: The form object is not set properly");
        return
    }
    if (r = this.formobj[n], typeof r == "undefined") {
        console.log("Error: Could not get the input object named: " + n);
        return
    }
    if (r.length && isNaN(r.selectedIndex) && (r = r[0]), !r) {
        alert("Error: Couldnot get the input object named: " + n);
        return
    }
    r.validationset || (r.validationset = new ValidationSet(r, this.show_errors_together));
    r.validationset.add(t, i, u);
    r.validatorobj = this
}

function validator_enable_OPED() {
    document.error_disp_handler.EnableOnPageDisplay(!1)
}

function validator_enable_OPED_SB() {
    document.error_disp_handler.EnableOnPageDisplay(!0)
}

function sfm_ErrorDisplayHandler() {
    this.msgdisplay = new AlertMsgDisplayer;
    this.EnableOnPageDisplay = edh_EnableOnPageDisplay;
    this.ShowMsg = edh_ShowMsg;
    this.FinalShowMsg = edh_FinalShowMsg;
    this.all_msgs = [];
    this.clear_msgs = edh_clear_msgs
}

function edh_clear_msgs() {
    this.msgdisplay.clearmsg(this.all_msgs);
    this.all_msgs = []
}

function edh_FinalShowMsg() {
    this.msgdisplay.showmsg(this.all_msgs)
}

function edh_EnableOnPageDisplay(n) {
    this.msgdisplay = !0 == n ? new SingleBoxErrorDisplay : new DivMsgDisplayer
}

function edh_ShowMsg(n, t) {
    var i = [];
    i.input_element = t;
    i.msg = n;
    this.all_msgs.push(i)
}

function AlertMsgDisplayer() {
    this.showmsg = alert_showmsg;
    this.clearmsg = alert_clearmsg
}

function alert_clearmsg() {}

function alert_showmsg(n) {
    var r = "",
        t = null;
    for (var i in n) null == t && (t = n[i].input_element), n[i].msg != undefined && (r += n[i].msg + "\n");
    alert(r);
    null != t && t.focus()
}

function sfm_show_error_msg(n, t) {
    document.error_disp_handler.ShowMsg(n, t)
}

function SingleBoxErrorDisplay() {
    this.showmsg = sb_div_showmsg;
    this.clearmsg = sb_div_clearmsg
}

function sb_div_clearmsg(n) {
    var t = form_error_div_name(n);
    show_div_msg(t, "")
}

function sb_div_showmsg(n) {
    var t = "<ul>\n",
        i, r;
    for (i in n) t += "<li>" + n[i].msg + "<\/li>\n";
    t += "<\/ul>";
    r = form_error_div_name(n);
    show_div_msg(r, t)
}

function form_error_div_name(n) {
    var t = null,
        r, i;
    for (r in n)
        if (t = n[r].input_element, t) break;
    return i = "", t && (i = t.form._sfm_form_name + "_errorloc"), i
}

function DivMsgDisplayer() {
    this.showmsg = div_showmsg;
    this.clearmsg = div_clearmsg
}

function div_clearmsg(n) {
    var t, i;
    for (t in n) i = element_div_name(n[t].input_element), show_div_msg(i, "")
}

function element_div_name(n) {
    var t = n.form._sfm_form_name + "_" + n.name + "_errorloc";
    return t.replace(/[\[\]]/gi, "")
}

function div_showmsg(n) {
    var t = null,
        i, r;
    for (i in n) null == t && (t = n[i].input_element), r = element_div_name(n[i].input_element), show_div_msg(r, n[i].msg);
    null != t && t.focus()
}

function show_div_msg(n, t) {
    if (n.length <= 0) return !1;
    if (document.layers) {
        if (divlayer = document.layers[n], !divlayer) return;
        divlayer.document.open();
        divlayer.document.write(t);
        divlayer.document.close()
    } else if (document.all) {
        if (divlayer = document.all[n], !divlayer) return;
        divlayer.innerHTML = t
    } else if (document.getElementById) {
        if (divlayer = document.getElementById(n), !divlayer) return;
        divlayer.innerHTML = t
    }
    return divlayer.style.visibility = "visible", !1
}

function ValidationDesc(n, t, i, r) {
    this.desc = t;
    this.error = i;
    this.itemobj = n;
    this.condition = r;
    this.validate = vdesc_validate
}

function vdesc_validate() {
    return this.condition != null && !eval(this.condition) ? !0 : validateInput(this.desc, this.itemobj, this.error) ? !0 : (this.itemobj.validatorobj.disable_validations = !0, this.itemobj.focus(), !1)
}

function ValidationSet(n, t) {
    this.vSet = [];
    this.add = add_validationdesc;
    this.validate = vset_validate;
    this.itemobj = n;
    this.msgs_together = t
}

function add_validationdesc(n, t, i) {
    this.vSet[this.vSet.length] = new ValidationDesc(this.itemobj, n, t, i)
}

function vset_validate() {
    for (var n = !0, t = 0; t < this.vSet.length; t++)
        if (n = n && this.vSet[t].validate(), !n && !this.msgs_together) break;
    return n
}

function validateEmail(n) {
    return /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(n)
}

function setCookie(n, t, i) {
    var r = new Date,
        u;
    r.setTime(r.getTime() + i * 864e5);
    u = "expires=" + r.toUTCString();
    document.cookie = n + "=" + t + "; " + u
}

function getCookie(n) {
    for (var t, r = n + "=", u = document.cookie.split(";"), i = 0; i < u.length; i++) {
        for (t = u[i]; t.charAt(0) == " ";) t = t.substring(1);
        if (t.indexOf(r) == 0) return t.substring(r.length, t.length)
    }
    return ""
}

function IsCheckSelected(n, t) {
    var f = !1,
        r = n.form.elements[n.name],
        u, i;
    if (r.length) {
        for (u = -1, i = 0; i < r.length; i++)
            if (r[i].value == t) {
                u = i;
                break
            }
        u >= 0 && r[u].checked == "1" && (f = !0)
    } else n.checked == "1" && (f = !0);
    return f
}

function TestDontSelectChk(n, t, i) {
    var r = !0;
    return r = IsCheckSelected(n, t) ? !1 : !0, r == !1 && (i && i.length != 0 || (i = "Can't Proceed as you selected " + n.name), sfm_show_error_msg(i, n)), r
}

function TestShouldSelectChk(n, t, i) {
    var r = !0;
    return r = IsCheckSelected(n, t) ? !0 : !1, r == !1 && (i && i.length != 0 || (i = "You should select" + n.name), sfm_show_error_msg(i, n)), r
}

function TestRequiredInput(n, t) {
    var r = !0,
        i = n.value;
    return n.classList.contains("hasPlaceholder") && n.placeholder == i && (i = ""), (eval(i.length) == 0 || i.match(/^\s+$/) !== null) && (t && t.length != 0 || (t = n.name + " : Required Field"), sfm_show_error_msg(t, n), r = !1), r
}

function TestMaxLen(n, t, i) {
    var r = !0;
    return eval(n.value.length) > eval(t) && (i && i.length != 0 || (i = n.name + " : " + t + " characters maximum "), sfm_show_error_msg(i, n), r = !1), r
}

function TestMinLen(n, t, i) {
    var r = !0;
    return eval(n.value.length) < eval(t) && (i && i.length != 0 || (i = n.name + " : " + t + " characters minimum  "), sfm_show_error_msg(i, n), r = !1), r
}

function TestInputType(n, t, i, r) {
    var u = !0,
        f = n.value.search(t);
    return n.value.length > 0 && f >= 0 && (i && i.length != 0 || (i = r), sfm_show_error_msg(i, n), u = !1), u
}

function TestEmail(n, t) {
    var i = !0;
    return n.value.length > 0 && !validateEmail(n.value) && (t && t.length != 0 || (t = n.name + ": Enter a valid Email address "), sfm_show_error_msg(t, n), i = !1), i
}

function TestLessThan(n, t, i) {
    var r = !0;
    return isNaN(n.value) ? (sfm_show_error_msg(n.name + ": Should be a number ", n), r = !1) : eval(n.value) >= eval(t) && (i && i.length != 0 || (i = n.name + " : value should be less than " + t), sfm_show_error_msg(i, n), r = !1), r
}

function TestGreaterThan(n, t, i) {
    var r = !0;
    return isNaN(n.value) ? (sfm_show_error_msg(n.name + ": Should be a number ", n), r = !1) : eval(n.value) <= eval(t) && (i && i.length != 0 || (i = n.name + " : value should be greater than " + t), sfm_show_error_msg(i, n), r = !1), r
}

function TestRegExp(n, t, i) {
    var r = !0;
    return n.value.length > 0 && !n.value.match(t) && (i && i.length != 0 || (i = n.name + ": Invalid characters found "), sfm_show_error_msg(i, n), r = !1), r
}

function TestDontSelect(n, t, i) {
    var r = !0;
    return n.value == null ? (sfm_show_error_msg("Error: dontselect command for non-select Item", n), r = !1) : n.value == t && (i && i.length != 0 || (i = n.name + ": Please Select one option "), sfm_show_error_msg(i, n), r = !1), r
}

function TestSelectOneRadio(n, t) {
    for (var u = n.form.elements[n.name], i = !1, r = 0; r < u.length; r++)
        if (u[r].checked == "1") {
            i = !0;
            break
        }
    return !1 == i && (t && t.length != 0 || (t = "Please select one option from " + n.name), sfm_show_error_msg(t, n)), i
}

function validateInput(n, t, i) {
    var r = !0,
        f = n.search("="),
        e = "",
        u = "";
    f >= 0 ? (e = n.substring(0, f), u = n.substr(f + 1)) : e = n;
    switch (e) {
        case "req":
        case "required":
            r = TestRequiredInput(t, i);
            break;
        case "maxlength":
        case "maxlen":
            r = TestMaxLen(t, u, i);
            break;
        case "minlength":
        case "minlen":
            r = TestMinLen(t, u, i);
            break;
        case "alnum":
        case "alphanumeric":
            r = TestInputType(t, "[^A-Za-z0-9]", i, t.name + ": Only alpha-numeric characters allowed ");
            break;
        case "alnum_s":
        case "alphanumeric_space":
            r = TestInputType(t, "[^A-Za-z0-9\\s]", i, t.name + ": Only alpha-numeric characters and space allowed ");
            break;
        case "num":
        case "numeric":
            r = TestInputType(t, "[^0-9]", i, t.name + ": Only digits allowed ");
            break;
        case "alphabetic":
        case "alpha":
            r = TestInputType(t, "[^A-Za-z]", i, t.name + ": Only alphabetic characters allowed ");
            break;
        case "alphabetic_space":
        case "alpha_s":
            r = TestInputType(t, "[^A-Za-z\\s]", i, t.name + ": Only alphabetic characters and space allowed ");
            break;
        case "email":
            r = TestEmail(t, i);
            break;
        case "phone":
            r = validatePhone(t, i);
            break;
        case "lt":
        case "lessthan":
            r = TestLessThan(t, u, i);
            break;
        case "gt":
        case "greaterthan":
            r = TestGreaterThan(t, u, i);
            break;
        case "regexp":
            r = TestRegExp(t, u, i);
            break;
        case "dontselect":
            r = TestDontSelect(t, u, i);
            break;
        case "dontselectchk":
            r = TestDontSelectChk(t, u, i);
            break;
        case "shouldselchk":
            r = TestShouldSelectChk(t, u, i);
            break;
        case "selone_radio":
            r = TestSelectOneRadio(t, i)
    }
    return r
}

function TestEmail(n, t) {
    var i = !0;
    return n.value.length > 0 && !validateEmail(n.value) && (t && t.length != 0 || (t = n.name + ": Enter a valid Email address "), sfm_show_error_msg(t, n), i = !1), i
}

function validatePhone(n, t) {
    var r = n.value,
        i = !1;
    r.length <= 0 && (i = !1);
    return s = stripCharsInBag(r, "()- +"), isInteger(s) && s.length >= 10 && (i = !0), t && t.length != 0 || (t = n.name + ": Phone number is invalid "), i || sfm_show_error_msg(t, n), i
}

function stripCharsInBag(n, t) {
    for (var u = "", r, i = 0; i < n.length; i++) r = n.charAt(i), t.indexOf(r) == -1 && (u += r);
    return u
}

function isInteger(n) {
    for (var i, t = 0; t < n.length; t++)
        if (i = n.charAt(t), i < "0" || i > "9") return !1;
    return !0
}

function VWZ_IsListItemSelected(n, t) {
    for (var i = 0; i < n.options.length; i++)
        if (n.options[i].selected == !0 && n.options[i].value == t) return !0;
    return !1
}

function VWZ_IsChecked(n, t) {
    if (n.length) {
        for (var i = 0; i < n.length; i++)
            if (n[i].checked == "1" && n[i].value == t) return !0
    } else if (n.checked == "1") return !0;
    return !1
}

function mailing_list() {
    return document.mailing.email.value == "" ? (alert("Please enter an email!"), !1) : jQuery("#gdpr_privacy_enforced").val() == "1" && document.mailing.subscribe.value == "1" ? (jQuery("#divPolicy").modal({
        containerCss: {
            borderWidth: "1px",
            width: "420px",
            height: "250px",
            backgroundColor: "#fff",
            padding: "12px"
        }
    }), !1) : !0
}

function mailing_list2() {
    return document.mailing2.email.value == "" ? (alert("Please enter an email!"), !1) : jQuery("#gdpr_privacy_enforced").val() == "1" && document.mailing2.subscribe.value == "1" ? (document.getElementById("policy_blog").value = 1, jQuery("#divPolicy").modal({
        containerCss: {
            borderWidth: "1px",
            width: "420px",
            height: "250px",
            backgroundColor: "#fff",
            padding: "12px"
        }
    }), !1) : !0
}

function Changeshippingtype(n) {
    n == 1 ? (country_object = "document.checkoutform.shipping_country", eval(country_object) && (document.checkoutform.shipping_type[0].checked = !0, select_field(country_object, "US"))) : document.checkoutform.shipping_type[1].checked = !0
}

function select_field(n, t) {
    for (i = 0; i <= eval(n + ".length") - 1; i++) eval(n + ".options[" + i + "].value") == t ? eval(n + ".options[" + i + "].selected=true") : eval(n + ".options[" + i + "].selected=false")
}

function checkselectedshipping() {}

function select_field(n, t) {
    for (i = 0; i <= eval(n + ".length") - 1; i++) eval(n + ".options[" + i + "].value") == t ? eval(n + ".options[" + i + "].selected=true") : eval(n + ".options[" + i + "].selected=false")
}

function Changeshippingtypeb(n) {
    n == 1 ? eval(country_object) && (document.billing.billing_type[0].checked = !0, country_object = "document.billing.billing_country", select_field(country_object, "US")) : document.billing.billing_type[1].checked = !0
}

function checkreq_questions1() {
    for (var t = document.forms.checkoutform, n = 0; n < t.elements.length; n++) {
        if (t.elements[n].name != undefined && t.elements[n].name.indexOf("OPTREQ") > -1)
            if (t.elements[n].type == "checkbox") {
                if (t.elements[n].checked != !0) return alert("Please fill in all required fields."), t.elements[n].focus(), !1
            } else if (t.elements[n].value <= "") return alert("Please fill in all required fields."), t.elements[n].focus(), !1;
        if (t.elements[n].type && t.elements[n].type.indexOf("text") > -1 && t.elements[n].name.indexOf("ocardno") <= -1 && t.elements[n].name.indexOf("Paymetric_") <= -1 && ExistsCreditCard(t.elements[n].value)) return alert(ccNumerNotAllowedMessage), !1
    }
    return submitForm()
}

function checkreq_questions3() {
    for (var t = document.forms.billing, n = 0; n < t.elements.length; n++) {
        if (t.elements[n].name != undefined && t.elements[n].name.indexOf("OPTREQ") > -1) {
            if (t.elements[n].name.indexOf("cq") > -1)
                if (t.elements[n].type == "checkbox") {
                    if (t.elements[n].checked != !0) return alert("Please fill in all required fields."), t.elements[n].focus(), !1
                } else if (t.elements[n].value <= "") return alert("Please fill in all required fields."), t.elements[n].focus(), !1;
            if (t.elements[n].name.indexOf("cka") > -1)
                if (t.elements[n].type == "radio") {
                    if (jQuery("input[name=" + t.elements[n].name + "]:checked").length <= 0) return alert("Please fill in all required fields."), t.elements[n].focus(), !1
                } else if (t.elements[n].type == "select-one" && jQuery("#" + t.elements[n].name + " option:selected").text().toLowerCase() === "select one") return alert("Please fill in all required fields."), t.elements[n].focus(), !1
        }
        if (t.elements[n].type && t.elements[n].type.indexOf("text") > -1 && t.elements[n].name.indexOf("ocardno") <= -1 && t.elements[n].name.indexOf("Paymetric_") <= -1 && ExistsCreditCard(t.elements[n].value)) return alert(ccNumerNotAllowedMessage), !1
    }
}

function checkreq_questions2() {
    for (var t = document.forms.pickship, n = 0; n < t.elements.length; n++) {
        if (t.elements[n].name != undefined && t.elements[n].name.indexOf("OPTREQ") > -1)
            if (t.elements[n].type == "checkbox") {
                if (t.elements[n].checked != !0) return alert("Please fill in all required fields."), t.elements[n].focus(), !1
            } else if (t.elements[n].value <= "") return alert("Please fill in all required fields."), t.elements[n].focus(), !1;
        if (t.elements[n].type && t.elements[n].type.indexOf("text") > -1 && t.elements[n].name.indexOf("ocardno") <= -1 && t.elements[n].name.indexOf("Paymetric_") <= -1 && ExistsCreditCard(t.elements[n].value)) return alert(ccNumerNotAllowedMessage), !1
    }
    return submitForm()
}

function checkotherreqfields() {
    var n = document.forms.billing,
        u, i, r = 0,
        t;
    if (n.payment != "undefined" && n.payment != null && n.payment.length != "undefined" && (r = n.payment.length), r > 0)
        for (counter = 0; counter < r; counter++) n.payment[counter].checked && (i = n.payment[counter].value);
    else n.payment != "undefined" && n.payment != null && (i = n.payment.value);
    if (i > "")
        for (u = i.split("-"), t = 0; t < n.elements.length; t++)
            if (n.elements[t].name != undefined && n.elements[t].name.indexOf("OPTREQ") > -1 && n.elements[t].name.indexOf("ff" + u[1] + "_") > -1 && n.elements[t].value <= "") return alert("Please fill in all required fields."), n.elements[t].focus(), !1;
    return CheckCreditCards() != !1 ? checkreq_questions3() != !1 ? submitForm() : !1 : !1
}

function CheckCreditCards() {
    var f = "",
        n, r, u, i, t, e, o, s, a, h, c, l;
    if (arguments.length == 1 && (f = arguments[0]), n = document.forms.billing, u = 0, f == "virtualterminal" ? u = 1 : n.payment != "undefined" && n.payment != null && n.payment.length != "undefined" && (u = n.payment.length), u > 0)
        for (counter = 0; counter < u; counter++) f == "virtualterminal" ? r = "online-" + n.payment.value : n.payment[counter].checked && (r = n.payment[counter].value);
    else n.payment != "undefined" && n.payment != null && (r = n.payment.value);
    if (r > "") {
        if (paymentinfo = r.split("-"), t = paymentinfo[1], r.indexOf("CIM") > 1) return !0;
        if (paymentinfo[0] == "transflow" && (i = eval("document.forms['billing'].ff" + t + "_ocardno"), i != undefined && i.value == "")) return alert("Please enter your mobile number."), !1;
        if (f == "virtualterminal" ? (i = eval("document.forms['billing'].ocardno"), e = eval("document.forms['billing'].ocardexpiresmonth"), o = eval("document.forms['billing'].ocardexpiresyear"), s = eval("document.forms['billing'].ocardcvv2")) : (i = eval("document.forms['billing'].ff" + t + "_ocardno"), e = eval("document.forms['billing'].ff" + t + "_ocardexpiresmonth"), o = eval("document.forms['billing'].ff" + t + "_ocardexpiresyear"), s = eval("document.forms['billing'].ff" + t + "_ocardcvv2"), l = eval("document.forms['billing'].hdnCvvRequired"), a = eval("document.forms['billing'].ff" + t + "_ocardtype"), h = eval("document.forms['billing'].ff" + t + "_ocheckrouting"), c = eval("document.forms['billing'].ff" + t + "_ocheckaccount")), s != undefined && l != undefined && s.value == "" && l.value == "1") return alert("Please enter CVV2 (Card Verification Code)"), !1;
        if (i != undefined && e != undefined && o != undefined) return CheckCardNumber(i, e, o, a);
        if (h != undefined && c != undefined) {
            if (h.value.replace(/^\s+|\s+$/g, "") == "") return alert("Please enter a Routing Number."), h.focus(), !1;
            if (c.value.replace(/^\s+|\s+$/g, "") == "") return alert("Please enter an Account Number."), c.focus(), !1
        } else return !0
    }
}

function CheckCardNumber(n, t, i, r) {
    var u, f, e;
    if (n.value.length == 0) return alert("Please enter a Card Number."), n.focus(), !1;
    if (i.type == "hidden") return !0;
    if (i.options[i.selectedIndex].value > 2e3) u = i.options[i.selectedIndex].value;
    else if (i.options[i.selectedIndex].value < 100) u = "20" + i.options[i.selectedIndex].value;
    else return alert("The Expiration Year is not valid. " + i.options[i.selectedIndex].value), !1;
    return (tmpmonth = t.options[t.selectedIndex].value, !(new CardType).isExpiryDate(u, tmpmonth)) ? (alert("This card has already expired."), !1) : (card = "MasterCard", f = !1, f = r == "undefined" || r == undefined ? (new CardType).checkCardNumber(n.value, u, tmpmonth, "") : r[r.selectedIndex].value.toLowerCase() == "maestro" && n.value.length == 18 ? !0 : isValidCreditCard(r.value, n.value), cardname = "", eval("document.forms['billing'].hdnVerifyCardType") != undefined && (e = eval("document.forms['billing'].hdnVerifyCardType.value")), f || e != "1" ? !0 : (alert("Credit card number is incorrect"), n.focus(), !1))
}

function CardType() {
    var n = CardType.arguments,
        t = CardType.arguments.length;
    this.objname = "object CardType";
    var i = t > 0 ? n[0] : "CardObject",
        r = t > 1 ? n[1] : "0,1,2,3,4,5,6,7,8,9",
        u = t > 2 ? n[2] : "13,14,15,16,19";
    return this.setCardNumber = setCardNumber, this.setCardType = setCardType, this.setLen = setLen, this.setRules = setRules, this.setExpiryDate = setExpiryDate, this.setCardType(i), this.setLen(u), this.setRules(r), t > 4 && this.setExpiryDate(n[3], n[4]), this.checkCardNumber = checkCardNumber, this.getExpiryDate = getExpiryDate, this.getCardType = getCardType, this.isCardNumber = isCardNumber, this.isExpiryDate = isExpiryDate, this.luhnCheck = luhnCheck, this
}

function checkCardNumber() {
    var n = checkCardNumber.arguments,
        t = checkCardNumber.arguments.length,
        i = t > 0 ? n[0] : this.cardnumber,
        r = t > 1 ? n[1] : this.year,
        u = t > 2 ? n[2] : this.month;
    return (this.setCardNumber(i), this.setExpiryDate(r, u), !this.isCardNumber()) ? !1 : this.isExpiryDate() ? !0 : !1
}

function getCardType() {
    return this.cardtype
}

function getExpiryDate() {
    return this.month + "/" + this.year
}

function isCardNumber() {
    var u = isCardNumber.arguments,
        f = isCardNumber.arguments.length,
        i = f > 0 ? u[0] : this.cardnumber,
        t, n, r;
    if (!this.luhnCheck()) return !1;
    for (t = 0; t < this.len.size; t++)
        if (i.toString().length == this.len[t]) {
            for (n = 0; n < this.rules.size; n++)
                if (r = i.substring(0, this.rules[n].toString().length), r == this.rules[n]) return !0;
            return !1
        }
    return !1
}

function isExpiryDate() {
    var n = isExpiryDate.arguments,
        t = isExpiryDate.arguments.length;
    return (year = t > 0 ? n[0] : this.year, month = t > 1 ? n[1] : this.month, !isNum(year + "")) ? !1 : isNum(month + "") ? (today = new Date, expiry = new Date(year, month), today.getTime() > expiry.getTime() ? !1 : !0) : !1
}

function isNum(n) {
    if (n = n.toString(), n.length == 0) return !1;
    for (var t = 0; t < n.length; t++)
        if (n.substring(t, t + 1) < "0" || n.substring(t, t + 1) > "9") return !1;
    return !0
}

function luhnCheck() {
    var f = luhnCheck.arguments,
        e = luhnCheck.arguments.length,
        i = e > 0 ? f[0] : this.cardnumber,
        n, t;
    if (!isNum(i)) return !1;
    var r = i.length,
        o = r & 1,
        u = 0;
    for (n = 0; n < r; n++) t = parseInt(i.charAt(n)), n & 1 ^ o || (t *= 2, t > 9 && (t -= 9)), u += t;
    return u % 10 == 0 ? !0 : !1
}

function makeArray(n) {
    return this.size = n, this
}

function setCardNumber(n) {
    return this.cardnumber = n, this
}

function setCardType(n) {
    return this.cardtype = n, this
}

function setExpiryDate(n, t) {
    return this.year = n, this.month = t, this
}

function setLen(t) {
    var i, r;
    for ((t.length == 0 || t == null) && (t = "13,14,15,16,19"), i = t, n = 1; i.indexOf(",") != -1;) i = i.substring(i.indexOf(",") + 1, i.length), n++;
    for (this.len = new makeArray(n), n = 0; t.indexOf(",") != -1;) r = t.substring(0, t.indexOf(",")), this.len[n] = r, t = t.substring(t.indexOf(",") + 1, t.length), n++;
    return this.len[n] = t, this
}

function setRules(t) {
    var i, r;
    for ((t.length == 0 || t == null) && (t = "0,1,2,3,4,5,6,7,8,9"), i = t, n = 1; i.indexOf(",") != -1;) i = i.substring(i.indexOf(",") + 1, i.length), n++;
    for (this.rules = new makeArray(n), n = 0; t.indexOf(",") != -1;) r = t.substring(0, t.indexOf(",")), this.rules[n] = r, t = t.substring(t.indexOf(",") + 1, t.length), n++;
    return this.rules[n] = t, this
}

function isValidCreditCard(n, t) {
    var r, u, i, f;
    if (n = n.toLowerCase(), n == "visa") r = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
    else if (n == "mc" || n == "mastercard" || n == "master") r = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
    else if (n == "disc" || n == "discover") r = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
    else if (n == "amex" || n == "americanexpress" || n == "american express") r = /^3[47]\d{13}$/;
    else if (n == "diners" || n == "diners club" || n == "dinersclub") r = /^3[068]\d{12}$/;
    else return !0;
    if (!r.test(t)) return !1;
    for (t = t.split("-").join(""), u = 0, i = 2 - t.length % 2; i <= t.length; i += 2) u += parseInt(t.charAt(i - 1));
    for (i = t.length % 2 + 1; i < t.length; i += 2) f = parseInt(t.charAt(i - 1)) * 2, u += f < 10 ? f : f - 9;
    return u % 10 == 0 ? !0 : !1
}

function get_Element(n) {
    return document.getElementById(n) || document.getElementsByName(n).item(0)
}

function getEl(n) {
    if (typeof n == "string") {
        if (document.getElementById(n)) return document.getElementById(n);
        if (document.forms[n]) return document.forms[n];
        if (document[n]) return document[n];
        if (window[n]) return window[n]
    }
    return n
}

function getFamily(n, t) {
    for (var r = t.elements, u = [], i = 0; i < r.length; i++) r[i].name == n.name && (u[u.length] = r[i]);
    return u
}

function getElemValue(n) {
    if (typeof jQuery == "undefined") return n.value;
    var t = jQuery(n),
        i = t.eq(0).val();
    return i == t.attr("placeholder") ? "" : i
}

function getValuesAsArray(n) {
    var r = {},
        i, t, h, e, f, c, s, u, o;
    for (n = getEl(n), i = n.elements, t = 0; t < i.length; t++)
        if (!i[t].disabled) {
            h = i[t].tagName.toLowerCase();
            switch (h) {
                case "input":
                    e = i[t].type.toLowerCase();
                    e || (e = "text");
                    switch (e) {
                        case "text":
                        case "image":
                        case "hidden":
                        case "password":
                            r[i[t].name] = getElemValue(i[t]);
                            break;
                        case "checkbox":
                            if (f = this.getFamily(i[t], n), f.length > 1)
                                for (r[i[t].name] = [], u = 0; u < f.length; u++) f[u].checked && (o = r[i[t].name].length, r[i[t].name][o] = getElemValue(f[u]));
                            else i[t].checked && (r[i[t].name] = getElemValue(i[t]));
                            break;
                        case "radio":
                            i[t].checked && (r[i[t].name] = getElemValue(i[t]))
                    }
                    break;
                case "select":
                    if (c = "", s = i[t].getAttribute("multiple"), s || s === "")
                        for (r[i[t].name] = [], u = 0; u < i[t].options.length; u++) o = r[i[t].name].length, i[t].options[u].selected && (r[i[t].name][o] = i[t].options[u].value);
                    else i[t] && i[t].options.length > 0 && (r[i[t].name] = i[t].options[i[t].selectedIndex].value);
                    break;
                case "textarea":
                    r[i[t].name] = getElemValue(i[t])
            }
        }
    return r
}

function isArray(n) {
    return n.constructor.toString().indexOf("Array") != -1 ? !0 : !1
}

function popup(n, t, i, r) {
    result = r > 0 ? window.open(n, "popped", "width=" + t + ", height=" + i + ", location=no, menubar=no, status=no, toolbar=no, scrollbars=yes, resizable=no") : window.open(n, "popped", "width=" + t + ", height=" + i + ", location=no, menubar=no, status=no, toolbar=no, scrollbars=no, resizable=no");
    result != null ? html = "is not blocking" : alert("Your Browser is blocking popups which is preventing a 3dCart window to appear.")
}

function VerifyStrongPass(n) {
    var t = 0,
        i = n.value;
    i.match(new RegExp(/(?=^.{8,16}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z]).*$/)) ? t = 100 : (t += i.match(new RegExp(/(?=.*\d).*$/)) ? 3 : 0, t += i.match(new RegExp(/(?=.*[a-z]).*$/)) ? 3 : 0, t += i.match(new RegExp(/(?=.*[A-Z]).*$/)) ? 4 : 0, t += i.match(new RegExp(/(?=.*[\W]+).*$/)) ? 3 : 0, t = t * i.length);
    document.getElementById("divStrong").style.width = 100 - t + "%"
}

function validateReqOption(n, t) {
    var o, u, h, e, r, i, f, c, s;
    for (o = t != undefined && t != null ? jQuery("#add" + t + " input[name=required_field]") : document.getElementsByName("required_field"), u = 0, e = 0; e < o.length; e++) {
        if (u = 0, o[e].value.indexOf("optionset") < 0 ? f = jQuery("[name='" + o[e].value + "']", n) : (c = o[e].value.split(":"), f = jQuery(document).find('[data-optionset="' + c[2] + '"]')), r = f[0], i = r.type, h = f.length == 1, f.closest(".opt-regular").removeClass("option-required"), i != null && i != undefined && (fieldnamemod = r.name, fieldnamemod != "")) {
            if (i == "radio" || i == "checkbox")
                if (h) r.checked && (u = 1);
                else
                    for (s = 0; s < f.length; s++) f[s].checked && (u = 1);
            (i == "hidden" || i == "password" || i == "text" || i == "textarea" || i == "file") && r.value > "" && (u = 1);
            (i == "select-one" || i == "select-multiple") && r.options[r.selectedIndex].value > "" && (u = 1)
        }
        if (u == 0) return r
    }
    return null
}

function ExistsCreditCard(n) {
    for (var i = new RegExp(/\b\d+[\.\ \-\d]+\d+\b/g), t;
        (t = i.exec(n)) !== null;)
        if (LuhnCheckCreditCard(t[0]) != "") return !0;
    return !1
}

function LuhnCheckCreditCard(n) {
    var e = new RegExp("^(?:4[0-9]{15}|4[0-9]{3}\\D\\d{4}\\D\\d{4}\\D\\d{4}|5[1-5][0-9]{14}|5[1-5]\\d{2}\\D\\d{4}\\D\\d{4}\\D\\d{4}|6(?:011|5[0-9][0-9])[0-9]{12}|6(?:011|5[0-9][0-9])[0-9]{12}|6(?:011|5[0-9][0-9])\\D\\d{4}\\D\\d{4}\\D\\d{4}|3[47][0-9]{13}|3[47][0-9]{2}\\D\\d{6}\\D\\d{5}|3(?:0[0-5]|[68][0-9])[0-9]{11}|3(?:0[0-5]|[68][0-9])[0-9]\\D\\d{6}\\D\\d{4}|((?:2131|1800|35\\d{3})\\d{11}|(?:2131|1800|35\\d{2})\\D\\d{4}\\D\\d{4}\\D\\d{4}))$", "g"),
        t;
    if (!n.match(e)) return "";
    var i = String(n).replace(/[^\d]/g, ""),
        o = [0, 2, 4, 6, 8, 1, 3, 5, 7, 9],
        u = 0,
        r, f = !1;
    for (t = i.length - 1; t >= 0; --t) r = parseInt(i.charAt(t), 10), u += (f = !f) ? r : o[r];
    return u % 10 == 0 ? i : ""
}

function ReviewAllShow(n) {
    add.review_sorting != null && add.review_sorting != "null" && add.review_sorting != undefined && add.review_sorting != "undefined" && (sort = add.review_sorting.options[add.review_sorting.selectedIndex].value, n = n + "&sort=" + add.review_sorting.options[add.review_sorting.selectedIndex].value);
    popup(n, 550, 400, !1)
}

function GetLanguagItem(n) {
    var t = "";
    return jQuery.ajax({
        url: "error.asp?msgType=2&itemName=" + n,
        type: "POST",
        dataType: "json",
        cache: !1,
        async: !1,
        success: function(n) {
            t = n.message
        },
        error: function(n) {
            console.log(n);
            t = "Something went wrong. Please try again."
        }
    }), t
}
window.addEventListener("message", function(n) {
    n.data == "closemodal" && jQuery.modal.close()
});
var isSubmitComplete = !1,
    paymentfound = 0,
    bolCheckSubmitted_validation = !0;
/*! @source http://purl.eligrey.com/github/classList.js/blob/master/classList.js*/
"document" in self && !("classList" in document.createElement("_")) && function(n) {
        "use strict";
        var u;
        if ("Element" in n) {
            var f = "classList",
                t = "prototype",
                e = n.Element[t],
                r = Object,
                l = String[t].trim || function() {
                    return this.replace(/^\s+|\s+$/g, "")
                },
                a = Array[t].indexOf || function(n) {
                    for (var t = 0, i = this.length; t < i; t++)
                        if (t in this && this[t] === n) return t;
                    return -1
                },
                o = function(n, t) {
                    this.name = n;
                    this.code = DOMException[n];
                    this.message = t
                },
                s = function(n, t) {
                    if (t === "") throw new o("SYNTAX_ERR", "An invalid or illegal string was specified");
                    if (/\s/.test(t)) throw new o("INVALID_CHARACTER_ERR", "String contains an invalid character");
                    return a.call(n, t)
                },
                h = function(n) {
                    for (var i = l.call(n.getAttribute("class") || ""), r = i ? i.split(/\s+/) : [], t = 0, u = r.length; t < u; t++) this.push(r[t]);
                    this._updateClassName = function() {
                        n.setAttribute("class", this.toString())
                    }
                },
                i = h[t] = [],
                c = function() {
                    return new h(this)
                };
            if (o[t] = Error[t], i.item = function(n) {
                    return this[n] || null
                }, i.contains = function(n) {
                    return n += "", s(this, n) !== -1
                }, i.add = function() {
                    var t = arguments,
                        i = 0,
                        u = t.length,
                        n, r = !1;
                    do n = t[i] + "", s(this, n) === -1 && (this.push(n), r = !0); while (++i < u);
                    r && this._updateClassName()
                }, i.remove = function() {
                    var t = arguments,
                        i = 0,
                        f = t.length,
                        r, u = !1,
                        n;
                    do r = t[i] + "", n = s(this, r), n !== -1 && (this.splice(n, 1), u = !0); while (++i < f);
                    u && this._updateClassName()
                }, i.toggle = function(n, t) {
                    n += "";
                    var i = this.contains(n),
                        r = i ? t !== !0 && "remove" : t !== !1 && "add";
                    return r && this[r](n), typeof t == "boolean" ? t : !i
                }, i.toString = function() {
                    return this.join(" ")
                }, r.defineProperty) {
                u = {
                    get: c,
                    enumerable: !0,
                    configurable: !0
                };
                try {
                    r.defineProperty(e, f, u)
                } catch (v) {
                    v.number === -2146823252 && (u.enumerable = !1, r.defineProperty(e, f, u))
                }
            } else r[t].__defineGetter__ && e.__defineGetter__(f, c)
        }
    }(self),
    function(n) {
        function t(n) {
            this.setting = i({
                close_delay: 2500,
                display_class: "mb--messagebar--show",
                disappear_class: "mb--messagebar--hide",
                default_class: "mb--messagebar",
                is_html: !1
            }, n);
            this.is_showing = !1;
            this.message_dom = null;
            this.initialized = !1;
            this.self_timer = null
        }
        var i = function(n, t) {
                for (var i in t) n[i] = t[i];
                return n
            },
            r = function(n) {
                var t = {};
                for (var i in n) t[i] = n[i];
                return t
            },
            u = function(n) {
                var t = {
                        "&": "&amp;",
                        "<": "&lt;",
                        ">": "&gt;",
                        '"': "&quot;",
                        "'": "&#x27;"
                    },
                    i = [],
                    r, u;
                for (r in t) i.push(r);
                return u = new RegExp("[" + i.join("") + "]", "g"), ("" + n).replace(u, function(n) {
                    return t[n]
                })
            };
        t.prototype.initialize = function() {
            this.message_dom = document.createElement("div");
            this.message_dom.classList.add(this.setting.default_class);
            var n = document.getElementsByTagName("body")[0];
            n.appendChild(this.message_dom);
            this.initialized = !0
        };
        t.prototype.show = function(n, t) {
            var f, e;
            if (!this.initialized) throw new Error("MessageBar is not initialized");
            this.is_showing && this.restore();
            this.is_showing = !0;
            f = i(r(this.setting), t);
            this.message_dom.innerHTML = f.is_html ? n : u(n);
            "string" == typeof f.display_class && (f.display_class = [f.display_class]);
            for (e in f.display_class) this.message_dom.classList.add(f.display_class[e]);
            this.message_dom.setAttribute("data-mb-disappear-class", f.disappear_class);
            this.self_timer = setTimeout(this.close.bind(this), f.close_delay)
        };
        t.prototype.close = function() {
            var n = this,
                t = this.message_dom.getAttribute("data-mb-disappear-class");
            this.message_dom.classList.add(t);
            setTimeout(function() {
                n.restore()
            }, 250)
        };
        t.prototype.restore = function() {
            this.is_showing = !1;
            this.message_dom.innerHTML = "";
            this.message_dom.className = this.setting.default_class;
            this.message_dom.removeAttribute("data-mb-disappear-class");
            clearTimeout(this.self_timer);
            this.self_timer = null
        };
        t.prototype.alert = function(n) {
            this.show(n, {
                display_class: ["mb--messagebar--show", "mb--messagebar--danger"]
            })
        };
        t.prototype.success = function(n) {
            this.show(n, {
                display_class: ["mb--messagebar--show", "mb--messagebar--success"]
            })
        };
        t.prototype.warning = function(n) {
            this.show(n, {
                display_class: ["mb--messagebar--show", "mb--messagebar--warning"]
            })
        };
        n.MessageBar = t
    }.call(this, this)