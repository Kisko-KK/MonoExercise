import axios from 'axios';
import { HttpHeader } from '../HttpHeader';

export const getCounties = async () => {
  try {
    const response = await axios.get('https://localhost:44332/api/County', { headers: HttpHeader.get() });
    return response.data;
  } catch (error) {
    console.log(error);
    return [];
  }
};


export const addNewCounty = async (county) => {
  try {
    await axios.post('https://localhost:44332/api/County', { Name: county.Name }, { headers: HttpHeader.get() });
    return true;
  } catch (error) {
    return false;
  }
};

export const deleteCounty = (id) => {
  return axios.delete(`https://localhost:44332/api/County/${id}`, { headers: HttpHeader.get() })
    .then(() => true)
    .catch((error) => {
      return false;
    });
};

export const getCounty = async (id) => {
  try {
    const response = await axios.get(`https://localhost:44332/api/County/${id}`, { headers: HttpHeader.get() });
    return response.data;
  } catch (error) {
    return null;
  }
};

export const updateCounty = async (id, name) => {
  try {
    await axios.put(`https://localhost:44332/api/County/${id}`, { Name: name }, { headers: HttpHeader.get() });
    return true;
  } catch (error) {
    return false;
  }
};