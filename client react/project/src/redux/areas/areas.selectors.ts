import { RootState } from "../store";

export const selectAreas = (state: RootState) => state.area.areas;