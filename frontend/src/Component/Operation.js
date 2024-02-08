
import { useState } from 'react';
import OperationField from './OperationField';
import axios from 'axios'

function Operation( {op} ) {

    const [first, setFirst] = useState("0");
    const [second, setSecond] = useState("0");
    const [result, setResult] = useState(" ");

    const src = op + ".png";
    const url = 'http://localhost:5218/calculator/api/v2' + op;

    const calculate = () => {

        axios.get(url, {
            params: {
                x: first,
                y: second
            }
        }).then(response => {
            setResult(response.data)
        }).catch(e => {
            setResult("invalid input")
        })

    }

    return <div className='operation'>
        <OperationField label="First Operand" value={first} setValue={setFirst} calculate={calculate}></OperationField>
        <img alt='missing' src={src}></img>
        <OperationField label="Second Operand" value={second} setValue={setSecond} calculate={calculate}></OperationField>
        <img alt='missing' src="equal.png"></img>
        <OperationField label="Result" value={result} setValue={setResult} calculate={calculate}></OperationField>
    </div>;
}

export default Operation;