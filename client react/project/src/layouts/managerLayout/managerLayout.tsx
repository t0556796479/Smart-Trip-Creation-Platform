import { Outlet } from "react-router-dom";
import ManagerPage from "../../pages/managerPage/managerPage";

export default function ManagerLayout() {
    return (
        <>
            <header><ManagerPage /></header>
            <main><Outlet /></main>
        </>
    );
}
