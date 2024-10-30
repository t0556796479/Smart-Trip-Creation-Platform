import { PayloadAction, createSlice } from '@reduxjs/toolkit'
import { AreaStateType, AreaType } from '../../types/areas.types';


const areasSlice = createSlice({
    name: 'areas',
    initialState: { areas: [] } as AreaStateType,
    reducers: {
        setAreas: (state: AreaStateType, action: PayloadAction<AreaType[]>) => {
            state.areas = action.payload;
        },
        addArea: (state: AreaStateType, action: PayloadAction<AreaType>) => {
            state.areas.push(action.payload)
        },
        deleteArea: (state: AreaStateType, action: PayloadAction<number>) => {
            state.areas = state.areas.filter(a => a.areaId !== action.payload)
        },
        updateArea: (state: AreaStateType, action: PayloadAction<AreaType>) => {
            const updateAreaId = state.areas.findIndex(a => a.areaId === action.payload.areaId)
            state.areas[updateAreaId] = action.payload
        }
    }
})

export const { setAreas, addArea, deleteArea, updateArea } = areasSlice.actions

export default areasSlice.reducer