import React from 'react';
import { Link } from "react-router-dom";

const SignUp = () => {
    return (
        <section className="vh-100 bg-image"
            style={{ backgroundImage: "url('https://mdbcdn.b-cdn.net/img/Photos/new-templates/search-box/img4.webp')" }}>
            <div className="mask d-flex align-items-center h-100 gradient-custom-3">
                <div className="container h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-12 col-md-9 col-lg-7 col-xl-6">
                            <div className="card" style={{ borderRadius: "15px" }}>
                                <div className="card-body p-5">
                                    <h2 className="text-center mb-5">Create an account</h2>

                                    <form>

                                        <div className="form-outline mb-4">
                                            <input type="text" id="form3Example1cg" className="form-control" placeholder="Your Name"/>
                                            <label className="form-label" htmlFor="form3Example1cg"></label>
                                        </div>

                                        <div className="form-outline mb-4">
                                            <input type="email" id="form3Example3cg" className="form-control" placeholder="Your Email"/>
                                            <label className="form-label" htmlFor="form3Example3cg"></label>
                                        </div>

                                        <div className="form-outline mb-4">
                                            <input type="password" id="form3Example4cg" className="form-control" placeholder="Password"/>
                                            <label className="form-label" htmlFor="form3Example4cg"></label>
                                        </div>

                                        <div className="form-outline mb-4">
                                            <input type="password" id="form3Example4cdg" className="form-control" placeholder="Repeat your password"/>
                                            <label className="form-label" htmlFor="form3Example4cdg"></label>
                                        </div>

                                        <div className="form-check d-flex justify-content-center mb-5">
                                            <input className="form-check-input me-2" type="checkbox" value="" id="form2Example3cg" />
                                            <label className="form-check-label" htmlFor="form2Example3g">
                                                I agree all statements in <a href="#!" className="text-body"><u>Terms of service</u></a>
                                            </label>
                                        </div>

                                        <div className="d-flex justify-content-center">
                                            <button type="button" className="btn btn-primary btn-block mb-4 w-100">Register</button>
                                        </div>

                                        <p className="text-center text-muted mt-3 mb-0">Have already an account? <Link to="/log-in"
                                            className="text-body"><u>Login here</u></Link></p>

                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default SignUp;
