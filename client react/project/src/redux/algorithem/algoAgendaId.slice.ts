import { createSlice } from '@reduxjs/toolkit'




const initialState: number = 1;

const algoAgendaIdSlice = createSlice({
    name: 'algoAgendaId',
    initialState,
    reducers: {
        setAlgoAgendaId: (state: number) => {
            state = state + 1;
            return state;
        },

    }
})

export const { setAlgoAgendaId } = algoAgendaIdSlice.actions

export default algoAgendaIdSlice.reducer