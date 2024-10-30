import axios from '../utils/axios'
import { AreaStateType } from '../types/areas.types'

export const getAreas = async () => {
    const response = await axios.get('/Areas')
    const areas = await response.data
    return areas
}

export const getAreaById = async (id:Number) => {
    const response = await axios.get(`/Areas/${id}`)
    const area = response.data
    return area
}

export const addArea = async (area:Omit<AreaStateType, 'areaId'>) => {
    const response = await axios.post('/Areas', area)
    const newArea = response.data
    return newArea
}

export const updateArea = async (area: AreaStateType, id: number) => {
    const response = await axios.put(`/Areas/${id}`, area)
    const updatedArea = response.data
    return updatedArea
}

export const deleteArea = async (id: number) => {
    const response = await axios.delete(`/Areas/${id}`)
    return response
}

