import React, { Component } from "react";
import { isServer } from "@sitecore-jss/sitecore-jss";
import jssRocksApi from "../../api/jssRocksApi";

class JssRocksForm extends Component {
  state = {};

  componentDidMount = () => {
    if (!isServer()) {
      // Do not call the JSS Rocks API during server-side rendering as it can
      // cause performance issues
      jssRocksApi.getContact().then(contact => this.setState({ ...contact }));
    }
  };

  getFormData = form => {
    const formData = new FormData(form);
    const { antiForgeryToken } = this.props.rendering;
    formData.append(antiForgeryToken.name, antiForgeryToken.value);
    return formData;
  };

  submitForm = event => {
    event.preventDefault();

    const formData = this.getFormData(event.target);
    jssRocksApi
      .submitForm(formData)
      .then(response => {
        if (!response.ok) {
          throw new Error("Uh oh.");
        }
        this.setState({ name: formData.get("name") });
      })
      .catch(() => window.alert("Uh oh. Something bad happened!"));
  };

  render() {
    return (
      <React.Fragment>
        {this.state.name && <p className="lead">Hello, {this.state.name}!</p>}
        <form className="text-center" onSubmit={this.submitForm}>
          <div className="form-group">
            <input
              name="name"
              type="text"
              placeholder="Name"
              className="form-control"
              required={true}
            />
          </div>
          <button className="btn btn-primary">Submit</button>
        </form>
      </React.Fragment>
    );
  }
}

export default JssRocksForm;
