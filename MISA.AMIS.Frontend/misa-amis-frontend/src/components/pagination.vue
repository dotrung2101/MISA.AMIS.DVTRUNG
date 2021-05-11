<template>
    <div class="pagination">
        <div class="count-title">Tổng số: <b> {{totalRecord}} </b>bản ghi</div>
        <div style="flex: 1"></div>
        <select v-model="pageSize">
            <option value="10">10 bản ghi trên 1 trang</option>
            <option value="20">20 bản ghi trên 1 trang</option>
            <option value="30">30 bản ghi trên 1 trang</option>
            <option value="50">50 bản ghi trên 1 trang</option>
            <option value="100">100 bản ghi trên 1 trang</option>
        </select>
        
    </div>
</template>

<script>
export default {
    name: "Pagination",
 props:{
     totalRecord: {
         type: Number,
         default: 0,
     },
     pageSize: {
         type: Number,
        default: 10,
     },
     currentPage: {
         type: Number,
         default: 1
     }
 }   
}
</script>

<style scoped>
.pagination{
    position: absolute;
    bottom: 0;
    width: 100%;
    height: 46px;
    display: flex;
    align-items: center;
}
</style>