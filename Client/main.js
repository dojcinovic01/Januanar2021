import { Grad } from "./Grad.js";
import { Mesec } from "./Mesec.js";


const sm=await fetch("https://localhost:5001/Grad/PreuzmiGradove");

const gradovi=await sm.json();
for(let m of gradovi){

    let listameseci=[];
    for(let mes of m.meseci){

        const ms=new Mesec(mes.id,mes.imeMeseca,mes.prosecnaTemp,mes.kolicinaPadavina,mes.suncaniDani);
        listameseci.push(ms);
       // console.log(ms);
        
    }


    const gr=new Grad(m.id,m.imeGrada,m.longituda,m.latituda,m.slikaGrada,m.godina,listameseci);
    
    gr.Crtaj(document.body);

}

