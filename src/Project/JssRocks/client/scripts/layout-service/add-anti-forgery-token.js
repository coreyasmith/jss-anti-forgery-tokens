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

const addAntiForgeryToken = (
  transformedRendering,
  currentManifest,
  request,
  response
) => {
  const manifestRendering = currentManifest.renderings.find(
    r => r.name == transformedRendering.componentName
  );
  if (!manifestRendering.addAntiForgeryToken) return undefined;

  return {
    ...transformedRendering,
    antiForgeryToken: getAntiForgeryToken(request, response)
  };
};

module.exports = addAntiForgeryToken;
