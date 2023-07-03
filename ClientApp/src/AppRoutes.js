import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import LogIn from './components/LogIn';
import SignUp from "./components/SignUp";
import Summarizer from "./components/Summarizer";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
    {
        path: '/log-in',
        element: <LogIn />
    },
    {
        path: '/sign-up',
        element: <SignUp />
    },
    {
        path: '/summarizer',
        element: <Summarizer />
    },
];

export default AppRoutes;
