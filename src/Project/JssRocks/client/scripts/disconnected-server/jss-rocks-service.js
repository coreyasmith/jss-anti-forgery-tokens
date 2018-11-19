let contact = {
  name: ""
};

class jssRocksService {
  static getContact(request, response) {
    response.json(contact);
  }

  static submitForm(request, response) {
    contact = (({ name }) => ({ name }))(request.body);
    response.sendStatus(200);
  }
}

module.exports = jssRocksService;
