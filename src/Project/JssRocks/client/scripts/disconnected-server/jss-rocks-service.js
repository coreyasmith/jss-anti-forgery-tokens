const validateAntiForgeryToken = require("./validate-anti-forgery-token");

let contact = {
  name: ""
};

class jssRocksService {
  static getContact(request, response) {
    response.json(contact);
  }

  static submitForm(request, response) {
    if (!validateAntiForgeryToken(request, response)) return;

    contact = (({ name }) => ({ name }))(request.body);
    response.sendStatus(200);
  }
}

module.exports = jssRocksService;
