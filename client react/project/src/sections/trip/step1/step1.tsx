import { Box } from "@mui/material";
import AutoComplete from "../../../components/googleMaps/autoComplete";
import { setAlgoAreaId, setAlgoEndPoint, setAlgoStartPoint } from "../../../redux/algorithem/algo.slice";
import { useAppDispatch } from "../../../redux/store";
import { PointType } from "../../../types/algorithem.type";
import SelectArea from "../../../components/select/selectArea";

export default function Step1() {
    const dispatch = useAppDispatch();
    const handleStartPointSelect = (startPoint: PointType) => {
        dispatch(setAlgoStartPoint(startPoint));
    };

    const handleEndPointSelect = (endPoint: PointType) => {
        dispatch(setAlgoEndPoint(endPoint));
    };
    const handleAreaSelect=(areaId:number)=>{
        dispatch(setAlgoAreaId(areaId));
    }

    return (
        <Box sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'center' }}>
            <AutoComplete onSelectLocation={handleStartPointSelect} lable="start point" />
            <AutoComplete onSelectLocation={handleEndPointSelect} lable="end point" />
            <SelectArea onSelectArea={handleAreaSelect}/>
        </Box>
    );
}
