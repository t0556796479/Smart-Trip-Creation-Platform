import { Outlet } from "react-router-dom";
import Home from "../../pages/homePage/home";

export default function MainLayout() {
    return (
        <>
            <header><Home /></header>
            <main><Outlet /></main>
        </>
    );
}
