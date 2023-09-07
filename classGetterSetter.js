// Interface 

interface toDo {
  userId: number;
  id: number;
  title: string;
  completed: boolean;
}

// AutoGenerate Class with Getter Setter
class _autoGen <T>{
    constructor(t: T) {
        Object.assign(this, t);
    }
    get<K extends keyof T>(k: K): T[K] {
        return (this as any as T)[k]; // assertion
    }
}
type autoGen<T> = T & _autoGen<T>;
const autoGen = _autoGen as new <T>(t: T) => autoGen<T>;

// Apply AutoGenerate Class
let toDoData = <toDos>{
    userId:1,
    id:1,
    title:"From User Data",
    completed:true
}
let toDoInterface = new autoGen<toDo>(toDoData)
