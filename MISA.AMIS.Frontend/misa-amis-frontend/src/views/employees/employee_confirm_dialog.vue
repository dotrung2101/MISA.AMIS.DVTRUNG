<template>
    <div class="confirm-dialog" v-bind:class="{show: isShow}">
        <div class="model-dialog">

        </div>
        <div class="content-dialog">
            <div style="height: 20px"></div>
            <div class="horizontal">
                <div class="mi mi-48 mi-exclamation-warning-48">

                </div>
                <div style="width: 20px"></div>
                <div class="message">Bạn có thực sự muốn xoá nhân viên này?</div>
            </div>
            <div style="height: 20px"></div>
            <div class="line"></div>
            <div style="height: 20px"></div>
            <div class="horizontal">
                <button class="second-button" v-on:click="close()">Không</button>
                <div style="flex: 1"></div>
                <button class="btn-primary" v-on:click="submit(employeeId)">Có</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "ConfirmDialog",
    data: function(){
        return {
            isShow: false,
            employeeId: "",
        }
    },
    methods: {
        show: function(employeeId){
            this.isShow = true;
            this.employeeId = employeeId;
        },
        close: function(){
            this.isShow = false;
        },
        submit: function(employeeId){
            console.log(employeeId);
            this.$parent.delete(employeeId);
            this.close();
        }
    }
}
</script>

<style scoped>
.confirm-dialog{
    display: none;
}
.confirm-dialog.show{
    display: block;
}
.model-dialog{
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
    z-index: 1000;
}
.content-dialog{
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translateX(-50%) translateY(-50%);
    width: 280px;
    height: 140px;
    padding: 32px;
    background: #fff;
    z-index: 1000;
}
.horizontal{
    display: flex;
    align-items: center;
    justify-content: center;
}
.line{
    width: 100%;
    height: 1px;
    background: #cccccc;
}
</style>