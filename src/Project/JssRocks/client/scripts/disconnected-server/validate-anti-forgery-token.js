const afTokenKey = "__RequestVerificationToken";

const validateAntiForgeryToken = (request, response) => {
  if (!request.body || !request.body[afTokenKey]) {
    response
      .status(400)
      .send(
        `The required anti-forgery form field "${afTokenKey}" is not present.`
      );
    return false;
  }

  if (!request.cookies || !request.cookies[afTokenKey]) {
    response
      .status(400)
      .send(`The required anti-forgery cookie "${afTokenKey}" is not present.`);
    return false;
  }

  return true;
};

module.exports = validateAntiForgeryToken;
