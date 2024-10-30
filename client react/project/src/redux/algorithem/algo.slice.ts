import { PayloadAction, createSlice } from '@reduxjs/toolkit'
import { AlgorithemType, PointType } from '../../types/algorithem.type';
import { AgendaStepType } from '../../types/agendaStep.type';



const initialState: AlgorithemType = {
    startPoint: null,
    endPoint: null,
    agenda: [],
    areaId: null,
};
const algorithemSlice = createSlice({
    name: 'algo',
    initialState,
    reducers: {
        setAlgoStartPoint: (state: AlgorithemType, action: PayloadAction<PointType>) => {
            state.startPoint = action.payload;
        },
        setAlgoEndPoint: (state: AlgorithemType, action: PayloadAction<PointType>) => {
            state.endPoint = action.payload;
        },
        setAlgoAreaId: (state: AlgorithemType, action: PayloadAction<number>) => {
            state.areaId = action.payload;
        },
        addStepToAgenda: (state: AlgorithemType, action: PayloadAction<AgendaStepType>) => {
            state.agenda?.push(action.payload)
        }
    }
})

export const { setAlgoStartPoint, setAlgoEndPoint, setAlgoAreaId, addStepToAgenda } = algorithemSlice.actions

export default algorithemSlice.reducer