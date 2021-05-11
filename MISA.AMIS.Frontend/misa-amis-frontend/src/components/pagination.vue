<template>
    <div class="pagination">
        <div class="count-title">Tổng số: <b> {{totalRecord}} </b>bản ghi</div>
        <div style="flex: 1"></div>
        <select v-model="pageSize" @change="$emit('onChangePageSize', $event.target.value)">
            <option value="10">10 bản ghi trên 1 trang</option>
            <option value="20">20 bản ghi trên 1 trang</option>
            <option value="30">30 bản ghi trên 1 trang</option>
            <option value="50">50 bản ghi trên 1 trang</option>
            <option value="100">100 bản ghi trên 1 trang</option>
        </select>
        <div style="width: 10px"></div>
        <div class="pager">
        <div
          class="page"
          :class="{ disable: page == 1 }"
          @click.prevent="$emit('onChangePage', page - 1)"
        >
          Trước
        </div>

        <div
          class="page"
          :class="{ active: page == 1 }"
          @click.prevent="$emit('onChangePage', 1)"
        >
          1
        </div>

        <div v-if="page > 3" class="page disable">...</div>

        <div
          v-for="p in pages"
          :key="p"
          class="page"
          :class="{ active: page == p }"
          @click.prevent="$emit('onChangePage', p)"
        >
          {{ p }}
        </div>

        <div v-if="page < totalPages - 3" class="page disable">...</div>

        <div
          class="page"
          :class="{ active: page == totalPages }"
          @click.prevent="$emit('onChangePage', totalPages)"
        >
          {{ totalPages }}
        </div>

        <div
          class="page"
          :class="{ disable: page == totalPages }"
          @click.prevent="$emit('onChangePage', page + 1)"
        >
          Sau
        </div>
        <div style="width: 10px"></div>
      </div>
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
     page: {
      type: Number,
      default: 1,
    },
     totalPages: {
      type: Number,
      default: 0,
    },

 } ,
 computed: {
    pages: function () {
      let ps = [];
      let start = this.page > 3 ? this.page - 1 : 2;
      let end =
        this.page < this.totalPages - 3 ? this.page + 1 : this.totalPages - 1;
      for (let i = start; i <= end; i++) ps.push(i);
      console.log(ps);
      return ps;
    },
  },  
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
.pager{
    display: flex;
}
.page{
    padding: 4px;
    cursor: pointer;
    line-height: 20px;
}
.disable{
    color: #aaaaaa;
}
.active{
    font-weight: bold;
    border: 1px solid #707070;
}
</style>