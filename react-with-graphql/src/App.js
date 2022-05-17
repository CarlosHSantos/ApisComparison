import logo from './logo.svg';
import './App.css';
import {
  ApolloClient,
  InMemoryCache,
  gql
} from "@apollo/client";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Data Loaded from GraphQL, see the console log.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

const client = new ApolloClient({
  uri: 'https://localhost:7118/graphql/',
  cache: new InMemoryCache(),
  headers: {
    "Access-Control-Allow-Origin": "*" // Required for CORS support to work
  },
  fetchOptions: {
    mode: 'no-cors',
  }
});

client
  .query({
    query: gql`
    query{
      searchUsers{
        id,
        name,
        surname,
        email,
        dDD,
        phone,
        password,
        role
      }
    }
    `
  })
  .then(result => console.log(result));

export default App;
