import { FormHelperText, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, Box } from '@mui/material';
import { useEffect, useState } from 'react';
import { selectAreas } from '../../redux/areas/areas.selectors';
import { useAppDispatch as useDispatch, useAppSelector as useSelector } from '../../redux/store'
import { getAreas as getAreasApi } from '../../services/areas.service';
import { setAreas } from '../../redux/areas/areas.slice';
import { AreaType } from '../../types/areas.types';

type SelectAreaProps = {
    onSelectArea: (areaId: number) => void
}

export default function SelectArea(p: SelectAreaProps) {

    const [selectedArea, setSelectedArea] = useState<AreaType>();

    const areas = useSelector(selectAreas)

    const dispatch = useDispatch()

    useEffect(() => {
        async function getAreas() {
            try {
                const areas = await getAreasApi();
                dispatch(setAreas(areas));
            } catch (error) {
                console.log(error);
            }
        }

        if (areas.length === 0) {
            getAreas();
        }
    }, []);



    const handleChange = (event: SelectChangeEvent<number>) => {
        const selectedArea = areas.find(
            (a) => a.areaId === event.target.value
        );
        setSelectedArea(selectedArea);
        if (selectedArea) {
            p.onSelectArea(selectedArea?.areaId);

        }
    };


    return (<>
        <Box sx={{ p: 2, border: '1px dashed grey', mr: 2 }}>
            <FormControl sx={{ m: 1, minWidth: 80 }}>
                <InputLabel id="demo-simple-select-autowidth-label">Area</InputLabel>
                <Select
                    labelId="demo-simple-select-autowidth-label"
                    id="demo-simple-select-autowidth"
                    value={selectedArea?.areaId}
                    autoWidth
                    label="area"
                    onChange={handleChange}>

                    {areas.map((a) => (
                        <MenuItem key={a.areaId} value={a.areaId}>
                            {a.areaName}
                        </MenuItem>
                    ))}
                </Select>
                <FormHelperText>choose an area</FormHelperText>
            </FormControl>
        </Box>
    </>
    );
}
