! function() {
    this.GambitSmoothScroll = function(t) {
        "undefined" == typeof t && (t = {});
        var e = {
            amount: 150,
            speed: 900
        };
        for (var i in e) t.hasOwnProperty(i) || (t[i] = e[i]);
        navigator.userAgent.match(/Mobi/) || (this.settings = t, this.startedAsTrackpad = !1, this.start())
    }, GambitSmoothScroll.prototype.start = function() {
        document.addEventListener("DOMContentLoaded", function() {
            window.addEventListener("wheel", this.overrideScroll.bind(this))
        }.bind(this))
    }, GambitSmoothScroll.prototype.stop = function(t, e) {
        "undefined" != typeof this.scrollInterval && (this.startedAsTrackpad = !1, clearInterval(this.scrollInterval), this.scrollInterval = void 0)
    }, GambitSmoothScroll.prototype.newScroll = function(t, e) {
        if (t !== this.isDown && "undefined" != typeof this.isDown && this.stop(), this.isDown = t, "undefined" == typeof this.scrollInterval) this.startingSpeed = this.settings.amount, this.scrollInterval = setInterval(function() {
            var t = (this.isDown ? 1 : -1) * this.startingSpeed / 15;
            window.scrollBy(0, t), this.startingSpeed *= 1 - 900 / this.settings.speed / 10, Math.abs(t) < 1 && this.stop()
        }.bind(this), 16.666666667);
        else {
            var i = 1 + (e - this.prevTimestamp) / 40 * .7;
            this.startingSpeed = Math.max(this.startingSpeed * i, this.settings.amount), this.startingSpeed = Math.min(this.startingSpeed, 300)
        }
        this.prevTimestamp = e
    }, GambitSmoothScroll.prototype.overrideScroll = function(t) {
        var e = t.wheelDelta ? -t.wheelDelta / 120 : (t.detail || t.deltaY) / 3,
            i = !1;
        return "undefined" != typeof window.mozInnerScreenX && -1 !== navigator.platform.indexOf("Mac") && (this.startedAsTrackpad = !1, i = !0, t.deltaY === parseInt(t.deltaY, 10)) ? void(this.startedAsTrackpad = !0) : ("undefined" != typeof this.trackpadTimeout && (clearTimeout(this.trackpadTimeout), this.trackpadTimeout = void 0), (Math.abs(e) < 1 || this.startedAsTrackpad) && !i ? (this.trackpadTimeout = setTimeout(function() {
            this.startedAsTrackpad = !1, this.trackpadTimeout = void 0
        }.bind(this), 200), this.startedAsTrackpad = !0, !0) : (t = t || window.event, t.preventDefault && t.preventDefault(), t.returnValue = !1, void this.newScroll(e > 0, t.timeStamp)))
    }
}();