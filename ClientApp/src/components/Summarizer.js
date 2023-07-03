import React, { Component } from 'react';

const Summarizer = () => {
    return (
        <div className="d-flex justify-content-center align-items-center pt-5">
            <form style={{ width: '500px' }}>
                <h2 className="text-center">Summarize Your Youtube Video</h2>
                <div className="form-outline mb-4 mt-5 ml-5">
                    <input type="email" id="form2Example1" className="form-control" placeholder="Youtube URL" />
                    <label className="form-label" htmlFor="form2Example1"></label>
                </div>


                <div className="form-outline mb-4">
                    <input type="password" id="form2Example2" className="form-control" placeholder="Word limits" />
                    <label className="form-label" htmlFor="form2Example2"></label>
                </div>



                <button type="button" className="btn btn-primary btn-block mb-4 w-100">Summarize</button>

            </form>
        </div>
    );

};

export default Summarizer;
