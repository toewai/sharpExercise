import axios from "axios";

const url = "https://jsonplaceholder.typicode.com/todos";

interface toDo {
  userId: number;
  id: number;
  title: string;
  completed: boolean;
}

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

type toDoType = toDo;

axios.get(url).then((res) => {
  let result: Array<autoGen<toDoType>> = [];
  
  let resData: toDoType[] = res.data;
  resData.forEach((element) => {
    let autoGenObj = new autoGen<toDoType>(element);
    result.push(autoGenObj);
  });

  console.log(result[199]);
});
