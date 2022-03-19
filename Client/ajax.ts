import axios from "axios";

axios.defaults.baseURL = "http://localhost:5001";

export const post = async (url: string, body: any) => {
  return axios.post(url, body);
};

export const get = (url: string) => {
  return axios.get(url);
};

export const remove = (url: string) => {
  return axios.delete(url);
};

export const put = (url: string, body: any) => {
  return axios.put(url, body);
};
