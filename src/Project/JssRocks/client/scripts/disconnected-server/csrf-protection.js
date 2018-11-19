const csrf = require("csurf");

const antiForgeryTokenKey = "__RequestVerificationToken";
exports.antiForgeryTokenKey = antiForgeryTokenKey;

exports.csrfProtection = csrf({
  cookie: { key: antiForgeryTokenKey },
  value: request => request.body[antiForgeryTokenKey]
});
