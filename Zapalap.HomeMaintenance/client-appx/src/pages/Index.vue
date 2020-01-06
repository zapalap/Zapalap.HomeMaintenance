<template>
  <q-page class="flex flex-start">
    <ProductGroupList />
  </q-page>
</template>

<script>
import ProductGroupList from '../components/ProductGroupList.vue'
export default {
  name: 'PageIndex',
  components: { ProductGroupList }
}
</script>
