export class Grad{

    constructor(id,naziv,lon,lat,slika,godina,meseci)
    {
        this.id=id;
        this.naziv=naziv;
        this.lon=lon;
        this.lat=lat;
        this.slika=slika;
        this.godina=godina;
        this.meseci=meseci;
        this.glavniCon=null;
    }

    Crtaj(host){

        this.glavniCon=document.createElement("div");
        this.glavniCon.classList.add("glavni-kontejner");
        host.appendChild(this.glavniCon);

        this.gradCon=document.createElement("div");
        this.gradCon.classList.add("grad-kontejner");
        this.glavniCon.appendChild(this.gradCon);

        this.labelaGrad=document.createElement("label");
        this.labelaGrad.classList.add("labela-grad");
        const labGrad='Grad'+' '+this.naziv+' '+'( '+this.lon+' N,'+ this.lat+' E), godina:'+this.godina;
        this.labelaGrad.innerText= labGrad;
        this.gradCon.appendChild(this.labelaGrad);

        this.slikaGrada=document.createElement("div");
        this.slikaGrada.classList.add("slika-grada");
        this.gradCon.appendChild(this.slikaGrada);

        this.buttonPrikazi=document.createElement("button");
        this.buttonPrikazi.classList.add('nadji-dugme');
        this.buttonPrikazi.innerText="PRIKAZI";
        this.gradCon.appendChild(this.buttonPrikazi);
       

        const img=document.createElement("img");
        img.classList.add('slika-nis');
        img.src=` https://belguest.rs/wp-content/uploads/2018/07/Trg-kralja-Milana-Nis.jpg`;
        this.slikaGrada.appendChild(img);

        const divButtons=document.createElement("div");
        divButtons.classList.add('select-dugmad');
        this.glavniCon.appendChild(divButtons);

        const opcije=[" Temperatura ", " Padavine ", " Suncani dani "];
        let combobox=document.createElement("select");
        divButtons.appendChild(combobox);
        let op;
        opcije.forEach((el,index)=>{
            
            op=document.createElement("option");
            op.innerText=el;
            op.value=index+1;
            combobox.appendChild(op);
        })

        const selItem=document.createElement("input");
        selItem.classList.add("select-polje");
        selItem.type="date";
        divButtons.appendChild(selItem);



        this.mesecCont=document.createElement("div");
        this.mesecCont.classList.add('mesec-kontejner');
        this.glavniCon.appendChild(this.mesecCont);

        this.mesecLevi=document.createElement("div");
        this.mesecLevi.classList.add('mesec-levi-kontejner');
        this.mesecCont.appendChild(this.mesecLevi);

        this.mesecDesni=document.createElement("div");
        this.mesecDesni.classList.add('mesec-desni-kontejner');
        this.mesecCont.appendChild(this.mesecDesni);

        this.buttonPrikazi.onclick=(ev)=>this.Prikazi();
        
        
        

    }

    Prikazi(){

         this.mesecCont.removeChild(this.mesecLevi);
         this.mesecLevi=document.createElement("div");
         this.mesecLevi.classList.add('mesec-levi-kontejner');
         this.mesecCont.appendChild(this.mesecLevi);
        //  let optionEl=this.kont.querySelector("select");
        // var ispitID=optionEl.options[optionEl.selectedIndex].value;
        let optionEl=this.glavniCon.querySelector("select");
        let vrednost=optionEl.options[optionEl.selectedIndex].value;
        let input=this.glavniCon.querySelector("input").value;
        alert(input);
        console.log(vrednost);
        
        for(let m of this.meseci){

            m.CrtajMesec(this.mesecLevi,vrednost);
            
        }

    }

   
}