import { FromSchema } from "json-schema-to-ts";
import axios from "axios";
const url = "https://jsonplaceholder.typicode.com/todos";

const toDoSchema = {
  type: "object",
  properties: {
    userId: { type: "number"},
    id: { type: "number" },
    title: { type: "string"},
    completed: { type: "boolean"},
  },
} as const;

type toDoType = FromSchema<typeof toDoSchema>;

class _autoGen<T> {
  constructor(t: T) {
    Object.assign(this, t);
  }
  get<K extends keyof T>(k: K): T[K] {
    return (this as any as T)[k]; // assertion
  }
}
type autoGen<T> = T & _autoGen<T>;
const autoGen = _autoGen as new <T>(t: T) => autoGen<T>;

axios.get(url).then((res) => {
  let result: Array<autoGen<toDoType>> = [];
  
  let resData: toDoType[] = res.data;
  resData.forEach((element) => {
    let autoGenObj = new autoGen<toDoType>(element);
    result.push(autoGenObj);
  });

  console.log(result[199]);
});
