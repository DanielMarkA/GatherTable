/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Components/**/*.{razor,html,cshtml}",
    "./wwwroot/**/*.html",
    "./App.razor"
  ],
  theme: {
    extend: {
      colors: {
        forest: {
          50: '#F1F7F4',
          100: '#E1EFE8',
          700: '#2C5E47',
          800: '#244E3B',
          900: '#1B3D2E',
          950: '#142C21',
        },
        cream: {
          50: '#FAFAF7',
          100: '#F7F6F0',
          200: '#F0EFE5',
          300: '#E6E4D8',
          400: '#D5D3C4',
        },
        slateleaf: {
          500: '#738078',
          700: '#46544C',
          900: '#233D32',
        },
        amberlight: {
          50: '#FFFDF9',
          100: '#FFF8EC',
          200: '#FEEFD3',
          800: '#945900',
        },
        alertred: {
          50: '#FDF7F6',
          100: '#FDECE8',
          200: '#F9D1C8',
          800: '#BC3A2B',
        }
      },
      fontFamily: {
        sans: ['"Inter"', 'ui-sans-serif', 'system-ui', '-apple-system', 'BlinkMacSystemFont', '"Segoe UI"', 'Roboto', '"Helvetica Neue"', 'Arial', 'sans-serif'],
      }
    },
  },
  plugins: [],
}
