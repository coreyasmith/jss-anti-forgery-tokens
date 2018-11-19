const {
  csrfProtection,
  antiForgeryTokenKey
} = require("../disconnected-server/csrf-protection");

const getAntiForgeryToken = (request, response) => {
  csrfProtection(request, response, () => {});
  return {
    name: antiForgeryTokenKey,
    value: request.csrfToken()
  };
};

const addAntiForgeryTokens = (
  routeRenderings,
  currentManifest,
  request,
  response
) => {
  const afTokenRenderings = currentManifest.renderings
    .filter(r => r.addAntiForgeryToken)
    .map(r => r.name.toLowerCase());

  routeRenderings
    .filter(r => afTokenRenderings.includes(r.componentName.toLowerCase()))
    .forEach(
      r => (r.antiForgeryToken = getAntiForgeryToken(request, response))
    );
};

module.exports = addAntiForgeryTokens;
