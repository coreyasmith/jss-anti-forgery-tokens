let contact = {
  name: ""
};

class jssRocksService {
  static getContact(request, response) {
    response.json(contact);
  }

  static submitForm(request, response) {
    if (request.body === null) {
      response.status(400).send("Bad request");
      return;
    }

    contact = (({ name }) => ({ name }))(request.body);
    response.sendStatus(200);
  }
}

module.exports = jssRocksService;
