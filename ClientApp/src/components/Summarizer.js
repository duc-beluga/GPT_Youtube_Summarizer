import React, { Component, useRef } from 'react';
import axios from 'axios';

const Summarizer = () => {

    const urlRef = useRef();
    const wordLimitRef = useRef();

    const summarize = async (e) => {
        e.preventDefault();
        console.log(urlRef.current.value)
        console.log(wordLimitRef.current.value)
        

        const transcriptionRequest = {
            videoUrl: urlRef.current.value,
            wordLimits: wordLimitRef.current.value
        }

        try {
            const response = await axios.post('https://localhost:44450/api/transcribe-summarize', transcriptionRequest);
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }

        urlRef.current.value = '';
        wordLimitRef.current.value = '';

    }
    return (
        <div className="d-flex justify-content-center align-items-center pt-5">
            <form style={{ width: '500px' }}>
                <h2 className="text-center">Summarize Your Youtube Video</h2>
                <div className="form-outline mb-4 mt-5 ml-5">
                    <input type="text" id="form2Example1" ref={urlRef} className="form-control" placeholder="Youtube URL" />
                    <label className="form-label" htmlFor="form2Example1"></label>
                </div>


                <div className="form-outline mb-4">
                    <input type="text" id="form2Example2" ref={wordLimitRef} className="form-control" placeholder="Word limits" />
                    <label className="form-label" htmlFor="form2Example2"></label>
                </div>



                <button onClick={ summarize } type="button" className="btn btn-primary btn-block mb-4 w-100">Summarize</button>

            </form>
        </div>
    );

};

export default Summarizer;
