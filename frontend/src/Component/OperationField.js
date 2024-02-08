
import TextField from '@mui/material/TextField';
import { useState, useEffect } from 'react';

function OperationField( {label, value, setValue, calculate} ){

    function getRandomInt(max) {
        return Math.floor(Math.random() * max);
    }

    const [color, setColor] = useState('color1');

    const handleOnChange = (e) => {
        if(label === 'Result') return;
        setValue(e.target.value);
    }

    useEffect(() => {
        let x = getRandomInt(12) + 1;
        console.log(x);
        setColor("color" + x.toString());
        }, []);

    useEffect(() => {
        if(label === 'Result') return;
        calculate();
    });

    return <TextField className='field' label={label} value={value} color={color} focused onChange={(e)=>handleOnChange(e)}/>;
}




export default OperationField;