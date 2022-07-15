import logo from '../logo.svg';

const HomePage = () => {
    return (
        <Header />
    );
}

export const Header = () => {
    return (
        <header className="App-header">
            <Img />
            <Message />
            <Link title="C#" url="https://reactjs.org" />
            <Link title="React" url="https://google.com" />
            <Link title="Angular" url="https://fb.com" />
        </header>
    );
}

export const Img = () => {
    return (
        <img src={logo} className="App-logo" alt="logo" />
    );
}

export const Message = () => {
    return (
        <p> Edit <code>src/App.js</code> and save to hola. </p>
    );
}

export const Link = ({ url, title }) => {
    return (
        <a
            className="App-link"
            href={url}
            target="_blank"
            rel="noopener noreferrer"
        >
            Learn {title}
        </a>
    );
}

export default HomePage;