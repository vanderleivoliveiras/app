"use strict";

Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _https = require("https");

var _https2 = _interopRequireDefault(_https);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var httpsFCASecurityRequestHelper = function () {
    function httpsFCASecurityRequestHelper() {
        _classCallCheck(this, httpsFCASecurityRequestHelper);

        this.securityAPIData = {
            endpoint: "security.fcalatam.com.br",
            serviceUserAuthority: {
                serviceName: "/service/security/userAuthority",
                serviceHttpMethod: "GET"
            },
            serviceAuth: {
                serviceName: "/service/security/auth",
                serviceHttpMethod: "POST"
            },
            serviceUserDataFromToken: {
                serviceName: "/service/security/user",
                serviceHttpMethod: "GET"
            },
            serviceUserDataFromUserId: {
                serviceName: "/adam/search/",
                serviceHttpMethod: "GET"
            },
            applicationCode: "FAST_FEEDBACK_PORTAL",
            viewCode: "MAIN",
            roleApplication: "ROLE_ACCESS_APPLICATION"
        };
    }

    _createClass(httpsFCASecurityRequestHelper, [{
        key: "verifyADUserCredentials",
        value: function verifyADUserCredentials() {
            this.headers = {
                "Content-Type": "application/json; charset=utf-8"
            };

            this.options = {
                host: this.securityAPIData.endpoint,
                path: this.securityAPIData.serviceAuth.serviceName,
                method: this.securityAPIData.serviceAuth.serviceHttpMethod,
                headers: this.headers
            };
            return this._makeRequest();
        }
    }, {
        key: "getUserInformationFromToken",
        value: function getUserInformationFromToken(token) {
            this.headers = {
                "Content-Type": "application/json; charset=utf-8",
                "Authorization": token
            };

            this.options = {
                host: this.securityAPIData.endpoint,
                path: this.securityAPIData.serviceUserDataFromToken.serviceName,
                method: this.securityAPIData.serviceUserDataFromToken.serviceHttpMethod,
                headers: this.headers
            };

            this.data = [];

            return this._makeRequest();
        }
    }, {
        key: "verifyUserSystemAuth",
        value: function verifyUserSystemAuth(token) {

            this.headers = {
                "Content-Type": "application/json; charset=utf-8",
                "Authorization": token
            };
            this.options = {
                host: this.securityAPIData.endpoint,
                path: this.securityAPIData.serviceUserAuthority.serviceName + "/" + this.securityAPIData.applicationCode + "/" + this.securityAPIData.viewCode,
                method: this.securityAPIData.serviceUserAuthority.serviceHttpMethod,
                headers: this.headers
            };

            this.data = [];

            return this._makeRequest();
        }
    }, {
        key: "_makeRequest",
        value: function _makeRequest() {
            var _this = this;

            return new Promise(function (resolve, reject) {

                var request = _https2.default.request(_this.options, function (response) {

                    response.setEncoding('utf8');

                    if (response.statusCode === 401) {
                        return reject(response);
                    }

                    if (response.statusCode < 200 || response.statusCode >= 300) {
                        return reject(response);
                    }

                    response.on('data', function (chunk) {
                        return resolve(chunk);
                    });
                });
                request.on('error', function (err) {

                    return reject({
                        success: false,
                        message: err
                    });
                });

                request.write(JSON.stringify(_this.data));
                request.end();
            });
        }
    }]);

    return httpsFCASecurityRequestHelper;
}();

exports.default = httpsFCASecurityRequestHelper;