import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { PATHS } from "../../routes/paths";

export default function ManagerPage() {

    const navigate = useNavigate();

    function handleAddTripObjectClick(): void {
        navigate(`${PATHS.managerAddTripObject}`);
    }

    return (
        <>
            <Button variant="contained" onClick={handleAddTripObjectClick}>Add TripObject</Button>
        </>
    );
}
