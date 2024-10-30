import { AgendaStepType } from "./agendaStep.type"



//אוביקט שאותו אני אשלח לאלגוריתם


export type PointType = {
    lat: number,
    lng: number,
    location: string

}
export type AlgorithemType = {
    startPoint: PointType | null,
    endPoint: PointType | null,
    agenda: AgendaStepType[] | null,
    areaId: number | null
}


