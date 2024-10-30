import { Navigate, createBrowserRouter } from 'react-router-dom';
import { PATHS } from './paths';
import Home from '../pages/homePage/home';
import Login from '../pages/signInPage/signInPage';
import SignUp from '../pages/joinPage/joinPage';
import Logout from '../pages/logoutPage/logoutPage';
import MainStepper from '../pages/tripPage/stepper';
import GuestGuard from '../sections/auth/guestGuard';
import ManagerPage from '../pages/managerPage/managerPage';
import AddTripObject from '../sections/manager/addTripObject';
import MainLayout from '../layouts/mainLayout/mainLayout';
import AuthGuard from '../sections/auth/authGuard';


export const router = createBrowserRouter([
    {
        path: PATHS.home,
        element: <Home />
    },
    {
        path: PATHS.signIn,
        element: <GuestGuard><Login /></GuestGuard>
    },
    {
        path: PATHS.join,
        element: <GuestGuard><SignUp /></GuestGuard>
    },
    {
        path: PATHS.logout,
        element: <AuthGuard><Logout /></AuthGuard>
    },
    {
        path: PATHS.mainStepper,
        element: <AuthGuard><MainStepper /></AuthGuard>
    },
    {
        path: PATHS.manager,
        element: <ManagerPage />
    },
    {
        path: PATHS.managerAddTripObject,
        element: <AddTripObject />,
    },
    {
        path: '/',
        element: <Navigate to={PATHS.home} />,
        index: true
    },
    {
        path: '*',
        element: <h1>404</h1>
    }
])

