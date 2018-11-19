import config from "../temp/config";

const urlEncodeFormData = formData => {
  const encodedEntries = [];
  for (var entry of formData.entries()) {
    encodedEntries.push(
      `${encodeURIComponent(entry[0])}=${encodeURIComponent(entry[1])}`
    );
  }
  const encodedFormData = encodedEntries.join("&").replace(/%20/g, "+");
  return encodedFormData;
};

class jssRocksApi {
  static apiUrl = `${config.sitecoreApiHost}/jssrocksapi/form?sc_apikey=${
    config.sitecoreApiKey
  }`;

  static getContact() {
    return fetch(jssRocksApi.apiUrl).then(response => response.json());
  }

  static submitForm(formData) {
    var encodedFormData = urlEncodeFormData(formData);
    return fetch(jssRocksApi.apiUrl, {
      method: "POST",
      credentials: "include", // required to send anti-forgery cookie
      headers: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      body: encodedFormData
    });
  }
}

export default jssRocksApi;
