import React, { Component } from 'react';
import { Link } from "react-router-dom";

const LogIn = () => {
    return (
        <div className="d-flex justify-content-center align-items-center pt-5">
        <form style={{width:'500px'} }>
            <h2 className="text-center">Sign In</h2>
            <div className="form-outline mb-4 mt-5 ml-5">
                <input type="email" id="form2Example1" className="form-control" placeholder="Email address" />
                <label className="form-label" htmlFor="form2Example1"></label>
            </div>


            <div className="form-outline mb-4">
                <input type="password" id="form2Example2" className="form-control" placeholder="Password" />
                <label className="form-label" htmlFor="form2Example2"></label>
            </div>


            <div className="row mb-4">
                <div className="col-auto d-flex justify-content-center">

                    <div className="form-check">
                        <input className="form-check-input" type="checkbox" value="" id="form2Example31"  />
                        <label className="form-check-label" htmlFor="form2Example31"> Remember me </label>
                    </div>
                </div>

                <div className="col d-flex justify-content-end">

                        <a href="#!">Forgot password?</a>

                </div>
            </div>
                

            <button type="button" className="btn btn-primary btn-block mb-4 w-100">Sign in</button>


            <div className="text-center">
                <p>Not a member? <Link to="/sign-up">Register</Link></p>
                <p>or sign up with:</p>
                <button type="button" className="btn btn-link btn-floating mx-1">
                    <i className="fab fa-facebook-f"></i>
                </button>

                <button type="button" className="btn btn-link btn-floating mx-1">
                    <i className="fab fa-google"></i>
                </button>

                <button type="button" className="btn btn-link btn-floating mx-1">
                    <i className="fab fa-twitter"></i>
                </button>

                <button type="button" className="btn btn-link btn-floating mx-1">
                    <i className="fab fa-github"></i>
                </button>
            </div>
            </form>
        </div>
    );

};

export default LogIn;
