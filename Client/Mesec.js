import { Grad } from "./Grad.js";
export class Mesec{

    constructor(id,ime,prosTemp,kolPadavina,suncaniDani){

        this.id=id;
        this.ime=ime;
        this.prosTemp=prosTemp;
        this.kolPadavina=kolPadavina;
        this.suncaniDani=suncaniDani;
    }

    CrtajMesec(host,vrednost){
       
        this.mesecDiv=document.createElement("div");
        this.mesecDiv.classList.add('mesec-div');
        host.appendChild(this.mesecDiv);

        this.stubic=document.createElement("div");
        this.stubic.classList.add('div-stubic');
        this.mesecDiv.appendChild(this.stubic);

        this.imeMesec=document.createElement("div");
        this.imeMesec.classList.add('ime-meseca');
        this.mesecDiv.appendChild(this.imeMesec);

        this.podatak=document.createElement("div");
        this.podatak.classList.add('podatak');
        this.mesecDiv.appendChild(this.podatak);

        this.labelaIme=document.createElement("label");
        this.labelaIme.innerText=this.ime;
        this.imeMesec.appendChild(this.labelaIme);

        this.labelaPodatak=document.createElement("label");

        let grafik;
        let proc;

        if(vrednost==1){
            grafik=this.prosTemp;
            proc=(grafik/30)*100;
        }
        if(vrednost==2){
            grafik=this.kolPadavina;
            proc=(grafik/1000)*100;
        }
        if(vrednost==3){
            grafik=this.suncaniDani;
            proc=(grafik/30)*100;
        }

         console.log(proc);
         this.labelaPodatak.innerText=grafik;
         this.podatak.appendChild(this.labelaPodatak);       

         
          const stub=document.createElement("div");
          stub.classList.add('stub');
          this.stubic.appendChild(stub);
          stub.style.backgroundColor='#0000ff';
          stub.style.height=`${proc}%`;
          stub.style.width=`${100}%`;

          this.stubic.onclick=(e)=>this.Forma();
    }

    Forma(){
    
        alert("Majmunee");
    }

}