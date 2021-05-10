<template>
    <div class="drop-box-container">
        <div class="btn-container">
            <div class="btn-edit">Sửa</div>
            <button class="btn-drop" v-on:click="dropDown($event)" v-on:focusout="removeDropDown()">
                <div class="mi mi-16 mi-arrow-up-blue" ></div>
            </button>
        </div>
    </div>
</template>

<script>
export default {
    name:"MyDropBox",
    data: function(){
        return {
            status: false,
        }
    },
    props:['employeeId'],
    methods: {
        dropDown: function(event){
            console.log(event.clientX);
            let dd = document.getElementsByClassName("drop-down")[0];
            if(dd){
                dd.remove();
            }
            if(this.status){
                let dropDown = document.createElement("div");
                dropDown.classList.add("drop-down");
                dropDown.innerHTML += "<ul><li>Nhân bản</li><li>Xóa</li><li>Ngừng sử dụng</li></ul>";
                document.getElementsByTagName("body")[0].appendChild(dropDown);
                dropDown = document.getElementsByClassName("drop-down")[0];
                dropDown.style.top = `${event.clientY}px`;
                dropDown.style.left = `${event.clientX - 20}px`;
                this.status = false;
            }
            else{
                this.status = true;
            }
        },
        removeDropDown: function(){
            let dd = document.getElementsByClassName("drop-down")[0];
            if(dd){
                dd.remove();
                this.status = true;
            }
        }
    }
}
</script>

<style scoped>
@font-face {
    font-family: "notosans-regular";
    src: url("../assets/fonts/notosans-regular.2cb88a13.woff2") format("opentype");
}

@font-face {
    font-family: "notosans-italic";
    src: url("../assets/fonts/notosans-italic.1c1aaac9.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-bold";
    src: url("../assets/fonts/notosans-bold.3ede5aff.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-semibold";
    src: url("../assets/fonts/notosans-semibold.df3e6dc4.woff2") format("opentype");
}
.drop-box-container{
    width: 100%;
    height: 100%;
    position: relative;
    background: white;
}

.btn-container{
    display: flex;
    align-items: center;
    width: 100%;
}

.btn-edit{
    font-size: 12px;
    font-family: notosans-bold;
    color: #0075c0;
    padding: 6px 2px 6px 16px;
}

.btn-drop:focus{
    border: 1px solid #0075c0;
}

.btn-drop{
    padding: 6px 10px;
    border: none;
    background: none;
}
</style>