const antiForgeryToken = {
  name: "__RequestVerificationToken",
  value: "available-in-connected-mode"
};

const addAntiForgeryTokens = (routeRenderings, currentManifest, response) => {
  const afTokenRenderings = currentManifest.renderings
    .filter(r => r.addAntiForgeryToken)
    .map(r => r.name.toLowerCase());

  routeRenderings
    .filter(r => afTokenRenderings.includes(r.componentName.toLowerCase()))
    .forEach(r => (r.antiForgeryToken = antiForgeryToken));

  response.cookie(antiForgeryToken.name, antiForgeryToken.value);
};

module.exports = addAntiForgeryTokens;
