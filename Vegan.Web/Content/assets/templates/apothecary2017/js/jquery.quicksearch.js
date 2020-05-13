(function(n) {
    var t = function(t, i, r) {
        var t, u, f;
        settings = n.extend({
            minimumCharacters: 3,
            searchDelay: 100,
            limitPerCategory: 5,
            actionFunction: null,
            align: "left",
            width: "300",
            showIcons: !0,
            showEffect: "scroll",
            hideEffect: "fade"
        }, r), this._settings = settings, t = n(t), u = n(document.createElement("div")), u.attr("class", "searchlight-balloon"), u.css({
            position: "absolute",
            zIndex: "1005",
            top: n('#searchBox input[type="text"]').outerHeight(!0),
            display: "none"
        }), settings.width == "auto" && u.css("width", t.outerWidth()), settings.align == "left" ? u.css("left", "0px") : settings.align == "right" && u.css("right", n("#searchBox").innerWidth() - (t.offset().left + t.outerWidth())), f = n(document.createElement("div")), f.attr("class", "searchlight-results-wrapper"), f.css({
            height: "100%"
        }), u.append(f), n("#searchBox form").append(u), this._input = t, this._container = u, this._searchURL = i, this._resultsContainer = f, t.bind("focus.searchlight", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            this.value.length >= settings.minimumCharacters && t.search(this.value)
        }), n("#searchBox").bind("mousedown.searchlight", {
            searchlight: this
        }, function(n) {
            for (var i = n.data.searchlight, t = n.target, r = 0; t;) {
                if (t == i._input[0] || t == i._container[0]) return;
                t = t.parentNode
            }
            i.hide()
        }), t.bind("keydown.searchlight", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            n.which == 38 && t._selectedRow > 0 ? t.selectRow(t._selectedRow - 1) : n.which == 40 && t._selectedRow < t._rowCount - 1 ? t.selectRow(t._selectedRow + 1) : n.which == 13 && t._selectedRow > -1 && t.activateRow(t._selectedRow), (n.which == 38 || n.which == 40) && n.preventDefault()
        }), t.bind("keyup.searchlight", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            t._searchDelayTimer && clearTimeout(t._searchDelayTimer), t._searchDelayTimer = setTimeout(function() {
                var n = t._input[0];
                n.value == t._previousQuery || (n.value.length >= settings.minimumCharacters ? t.search(n.value) : t.hide())
            }, settings.searchDelay)
        }), t.bind("keypress.searchlight", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight
        }), this._container.bind("mouseleave.searchlight", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            t.selectRow(-1)
        }), this.resultAction = settings.actionFunction ? settings.actionFunction : this.defaultResultAction
    };
    t.prototype.show = function() {
        this._container.is(":visible") || this._container.fadeIn("fast")
    }, t.prototype.hide = function() {
        this._disableHide || this._container.fadeOut("fast")
    }, t.prototype.search = function(t) {
        var i = this;
        this._previousQuery = t, this._previousXHR && this._previousXHR.abort(), this._previousXHR = n.getJSON(this._searchURL, {
            q: t
        }, function(n) {
            var t, r;
            for (i.clearResults(), t = 0; t < n.length; t++) r = n[t], r.results.length > 0 && i.addResultCategory(r.title, r.results);
            i.show()
        })
    }, t.prototype.clearResults = function() {
        this._categoryCount = 0, this._rowCount = 0, this._selectedRow = -1, this._resultsContainer.html('<table class="searchlight-results"><\/table>')
    }, t.prototype.addResultCategory = function(t, i) {
        for (var h = !0, u, s, e, r, f, o = 0; o < i.length; o++) u = i[o], r = document.createElement("tr"), n(r).attr("class", "searchlight-not-selected"), f = document.createElement("td"), n(f).html('<span class="searchlight-result-text"><\/span>'), s = f.firstChild, this._settings.showIcons && (e = document.createElement("img"), e.className = "searchlight-result-icon", e.style.width = "50px", e.src = u[2] ? u[2] : "assets/templates/common-html5/images/spacer.gif", n(s).append(e)), n(s).append(u[1]), n(s).append("<br><span align=right class=search-price>" + u[3] + "<\/span>&nbsp;<img src='assets/templates/common-html5/images/star" + u[4] + ".png'>"), n(r).append(f), n(r).bind("mousemove", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            t.selectRow(this._rowId)
        }), n(r).bind("click", {
            searchlight: this
        }, function(n) {
            var t = n.data.searchlight;
            t.activateRow(this._rowId)
        }), r._rowId = this._rowCount, r._actionValue = u[0], this._resultsContainer.children("table").append(r), this._rowCount++;
        r = document.createElement("tr"), f = document.createElement("td"), r.className = "searchlight-spacer-row", n(r).append(f), this._resultsContainer.children("table").append(r), this._categoryCount++
    }, t.prototype.selectRow = function(t) {
        this._selectedRow = t, this._resultsContainer.find("tr:not(.searchlight-spacer-row)").each(function() {
            this._rowId == t ? n(this).hasClass("searchlight-selected") || (n(this).removeClass("searchlight-not-selected"), n(this).addClass("searchlight-selected")) : n(this).hasClass("searchlight-not-selected") || (n(this).removeClass("searchlight-selected"), n(this).addClass("searchlight-not-selected"))
        })
    }, t.prototype.activateRow = function(n) {
        this.resultAction(this._resultsContainer.find("tr:not(.searchlight-spacer-row):eq(" + n + ")")[0]._actionValue)
    }, t.prototype.defaultResultAction = function(n) {
        window.location.href = n
    }, n.fn.searchlight = function(n, i) {
        this.each(function() {
            new t(this, n, i)
        })
    }
})(jQuery)