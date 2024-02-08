import './App.css';
import Operation from './Component/Operation';
import { createTheme, ThemeProvider } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    color1: {
      main: '#76ff03'
    },
    color2: {
      main: '#e91e63'
    },
    color3: {
      main: '#9c27b0'
    },
    color4: {
      main: '#673ab7'
    },
    color5: {
      main: '#3f51b5'
    },
    color6: {
      main: '#009688'
    },
    color7: {
      main: '#4caf50'
    },
    color8: {
      main: '#cddc39'
    },
    color9: {
      main: '#ffc107'
    },
    color10: {
      main: '#ef6c00'
    },
    color11: {
      main: '#d500f9'
    },
    color12: {
      main: '#1de9b6'
    }
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
    <div className='container'>
      <Operation op='add'></Operation>
      <Operation op='subtract'></Operation>
      <Operation op='multiply'></Operation>
      <Operation op='divide'></Operation>
    </div>
    </ThemeProvider>
  );
}

export default App;
