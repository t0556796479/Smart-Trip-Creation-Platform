import { AlgorithemType } from '../types/algorithem.type'
import axios from '../utils/axios'

export const GetRoute = async (algorithem: AlgorithemType) => {
    const response = await axios.post('/Algorithem', algorithem);
    const algorithemRespose = await response.data;
    return algorithemRespose;
}

export const GetPropertiesByCategory = async (categoryId: Number) => {
    // פונקציה שמחזירה רשימה של פילטרים ולכל פילטר את המאפינים שלו לפי הקטגוריה שנשלחה
    const response = await axios.get(`/Algorithem/${categoryId}`)
    const propertiesList = response.data;
    return propertiesList;
}
